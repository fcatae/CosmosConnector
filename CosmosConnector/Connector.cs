using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector
{
    public class Connector
    {
        public static async Task Start(IPartitionManager sourceFactory, IDataTarget dataTarget)
        {
            var partitionList = await sourceFactory.ListPartitionsAsync();

            var taskList = from partition in partitionList
                           let sourcePartition = sourceFactory.CreatePartitionSource(partition)
                           // let targetPartition = ...
                           let runTask = Process(sourcePartition, dataTarget)
                           select runTask;

            Task.WaitAll(taskList.ToArray());
        }

        static async Task Process(IDataSource dataSource, IDataTarget dataTarget)
        {
            dataSource.Init();
            dataTarget.Init();

            while (true)
            {
                var messageList = await dataSource.ReadMessagesAsync();

                foreach (var message in messageList)
                {
                    await dataTarget.ProcessAsync(message);
                }
            }
        }
    }
}
