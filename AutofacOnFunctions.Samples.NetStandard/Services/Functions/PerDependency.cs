using System;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    public class PerDependency : IPerDependency
    {
        private readonly ILogger _logger;
        private readonly Guid _myGuid;

        public PerDependency(ILogger logger)
        {
            _logger = logger;
            _logger.LogWarning("PerDependency - " + Guid.NewGuid().ToString().Split('-')[0]);
            _myGuid = Guid.NewGuid();
        }

        public string CallMe()
        {
            _logger.LogCritical("PerDependency - CallMe");
            return $"From PerDependency ==> myGuid: {_myGuid}\n";
        }
    }
}