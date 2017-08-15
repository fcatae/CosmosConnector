using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector
{
    public interface IDataSource
    {
        void Init();
        Task<IEnumerable<IDataMessage>> ReadMessagesAsync();
        void Close();
    }
}
