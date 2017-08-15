using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector
{
    public interface IPartitionManager
    {
        void Init();
        Task<IEnumerable<IPartitionInfo>> ListPartitionsAsync();
        IDataSource CreatePartitionSource(IPartitionInfo partitionInfo);
        void Close();
    }
}
