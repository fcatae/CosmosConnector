using System;
using System.IO;
using System.Threading.Tasks;
using CosmosConnector.Components;

namespace CosmosConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cosmos Connector");

            IDataSource dataSource = new SimpleSource();
            IDataTarget dataTarget = new ConsoleTarget();

            var taskRunAsync = Process(dataSource, dataTarget);

            Console.ReadKey();
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