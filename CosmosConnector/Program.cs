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

            IDataSource dataSource = new ConsoleSource();
            IDataTarget dataTarget = new ConsoleTarget();

             IPartitionManager sourceFactory = new MultipleConsoles();

            //var taskRunAsync = Process(dataSource, dataTarget);

            Connector.Start(sourceFactory, dataTarget).Wait();

            Console.ReadKey();
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