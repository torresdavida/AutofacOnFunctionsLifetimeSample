using System;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    public class PerLifetimeScope : IPerLifetimeScope
    {
        private readonly ILogger _logger;
        private readonly Guid _myGuid;

        public PerLifetimeScope(ILogger logger)
        {
            _logger = logger;
            _logger.LogWarning("PerLifetimeScope - " + Guid.NewGuid().ToString().Split('-')[0]);
            _myGuid = Guid.NewGuid();
        }

        public string CallMe()
        {
            _logger.LogCritical("PerLifetimeScope - CallMe");
            return $"From PerLifetimeScope ==> myGuid: {_myGuid}\n";
        }
    }
}