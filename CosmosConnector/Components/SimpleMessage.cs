using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosConnector.Components
{
    public class SimpleMessage : IDataMessage
    {
        private string _message;

        public SimpleMessage(string message)
        {
            _message = message;
        }

        public string GetContent()
        {
            return _message;
        }
    }
}
