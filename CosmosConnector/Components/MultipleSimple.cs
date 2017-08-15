using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector.Components
{
    public class MultipleSimple : IPartitionManager
    {
        private int _partitionCount;

        public MultipleSimple(int partitionCount)
        {
            _partitionCount = partitionCount;
        }

        public void Init()
        {
        }

        public Task<IEnumerable<IPartitionInfo>> ListPartitionsAsync()
        {
            var partitionList = new List<IPartitionInfo>();

            for(int id=0; id<_partitionCount; id++)
            {
                string partitionId = id.ToString();

                partitionList.Add(new PartitionInfo(partitionId));
            }

            return Task.FromResult<IEnumerable<IPartitionInfo>>(partitionList);
        }

        public IDataSource CreatePartitionSource(IPartitionInfo partitionInfo)
        {
            string name = $"Partition {partitionInfo.PartitionId}";
            return new SimpleSource(name);
        }

        public void Close()
        {            
        }

        public IDataTarget CreateTarget(IPartitionInfo partitionInfo)
        {
            throw new NotImplementedException();
        }
    }
}
