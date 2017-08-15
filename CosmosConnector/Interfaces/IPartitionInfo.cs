using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosConnector
{
    public interface IPartitionInfo
    {
        string PartitionId { get; }
    }

    public class PartitionInfo : IPartitionInfo
    {
        private string _partitionId;

        public PartitionInfo(string partitionId)
        {
            this._partitionId = partitionId;
        }
        public string PartitionId => _partitionId;
    }
}
