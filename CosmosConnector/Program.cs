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

            IPartitionManager sourceFactory = new MultipleSimple(10);

            var taskRunAsync = Process(sourceFactory, dataTarget);

            Console.ReadKey();
        }

    }
}