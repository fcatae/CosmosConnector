using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector.Components
{
    class ConsoleTarget : IDataTarget
    {
        public void Init()
        {            
        }

        public Task ProcessAsync(IDataMessage message)
        {
            Console.WriteLine(message.GetContent());

            return Task.CompletedTask;
        }

        public void Close()
        {
        }

    }
}
