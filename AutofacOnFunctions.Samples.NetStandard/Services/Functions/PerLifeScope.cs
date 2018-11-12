using Microsoft.Extensions.Logging;
using System;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    public class PerLifetimeScope : IPerLifetimeScope
    {
        private readonly ILogger _logger;
        private readonly string _myGuid;

        public PerLifetimeScope(ILogger logger)
        {
            _myGuid = Guid.NewGuid().ToString().Split('-')[0];
            _logger = logger;
            _logger.LogWarning($"PerLifetimeScope - ctor - {_myGuid}");
        }

        public string CallMe()
        {
            _logger.LogWarning($"PerLifetimeScope - CallMe - {_myGuid}");
            return "";
        }
    }
}