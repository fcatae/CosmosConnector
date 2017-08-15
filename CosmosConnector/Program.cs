using System;
using System.IO;
using System.Threading.Tasks;
using CosmosConnector.Components;
using System.Collections.Generic;
using System.Linq;

namespace CosmosConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cosmos Connector");

            IDataSource dataSource = new SimpleSource();
            IDataTarget dataTarget = new ConsoleTarget();

            IPartitionManager sourceFactory = new MultipleSimpleSources(10);

            var taskRunAsync = Process(sourceFactory, dataTarget);

            Console.ReadKey();
        }

        static async Task Process(IPartitionManager sourceFactory, IDataTarget dataTarget)
        {
            var partitionList = await sourceFactory.ListPartitionsAsync();
            
            var taskList = from partition in partitionList
                           let sourcePartition = sourceFactory.CreatePartitionSource(partition)
                           let runTask = Process(sourcePartition, dataTarget)
                           select runTask;

            Task.WaitAll(taskList.ToArray());
        }

        static async Task Process(IDataSource dataSource, IDataTarget dataTarget)
        {
            dataSource.Init();
            dataTarget.Init();

            while(true)
            {
                var messageList = await dataSource.ReadMessagesAsync();

                foreach(var message in messageList)
                {
                    await dataTarget.ProcessAsync(message);
                }
            }
        }
    }
}