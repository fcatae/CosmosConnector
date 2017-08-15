using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector.Components
{
    class MultipleConsoles : IPartitionManager
    {
        public void Init()
        {            
        }

        public Task<IEnumerable<IPartitionInfo>> ListPartitionsAsync()
        {
            var partition = new PartitionInfo("SinglePartition");
            IEnumerable<IPartitionInfo> partitionList = new IPartitionInfo[1] { partition };

            return Task.FromResult(partitionList);
        }

        public IDataSource CreatePartitionSource(IPartitionInfo partitionInfo)
        {
            return new ConsoleSource();
        }

        public IDataTarget CreateTarget(IPartitionInfo partitionInfo)
        {
            return new ConsoleTarget();
        }
        
        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
