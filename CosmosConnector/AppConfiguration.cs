using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace CosmosConnector
{
    class AppConfiguration
    {
        public class AppConfigurationException : Exception
        {
            public AppConfigurationException(string message) : base(message)
            {
            }
        }

        private string _configName { get; }
        private IConfigurationRoot _config;

        public AppConfiguration(string configName)
        {
            _configName = configName;

            var builder = new ConfigurationBuilder()
                            .AddEnvironmentVariables(configName)
                            .AddUserSecrets("CosmosConnector-20171508");

            _config = builder.Build();
        }

        public string Get(string key)
        {
            string value = _config[key];

            if (value == null || value == "")
                throw new AppConfigurationException($"Configuration [{key}] is empty");

            return value;
        }
    }
}
