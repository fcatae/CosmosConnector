using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector.Components
{
    public class ConsoleSource : IDataSource
    {
        public void Init()
        {
        }

        public Task<IEnumerable<IDataMessage>> ReadMessagesAsync()
        {
            Console.Write("> ");
            string line = Console.ReadLine();            

            var message = new SimpleMessage(line);

            IEnumerable<IDataMessage> result = new IDataMessage[1] { message };

            return Task.FromResult(result);
        }

        public void Close()
        {            
        }
    }
}
