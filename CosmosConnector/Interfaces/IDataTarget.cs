using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector
{
    public interface IDataTarget
    {
        void Init();
        Task ProcessAsync(IDataMessage message);
        void Close();
    }
}
