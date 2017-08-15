using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector.Components
{
    class SimpleSource : IDataSource
    {
        private const int TotalMessages = 10;
        private const int TotalDelay = 1000;
        private int _instanceCount;

        public void Init()
        {
            _instanceCount = 0;
        }

        public async Task<IEnumerable<IDataMessage>> ReadMessagesAsync()
        {
            List<IDataMessage> messageList = new List<IDataMessage>();

            for(int i=0; i<TotalMessages; i++)
            {
                messageList.Add(new SimpleMessage($"Message #{_instanceCount++}"));
            }

            await Task.Delay(TotalDelay);

            return messageList;
        }

        public void Close()
        {
        }
    }
}
