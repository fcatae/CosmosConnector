using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosConnector
{
    public interface IStorage
    {
        object GetAsync(string key);
        Task SetAsync(string key, object value);
    }
}
