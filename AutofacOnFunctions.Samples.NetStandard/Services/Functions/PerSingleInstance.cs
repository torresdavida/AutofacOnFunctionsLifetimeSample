using System;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    public class PerSingleInstance : IPerSingleInstance
    {
        private readonly ILogger _logger;
        private readonly Guid _myGuid;

        public PerSingleInstance(ILogger logger)
        {
            _logger = logger;
            _logger.LogWarning("PerSingleInstance - " + Guid.NewGuid().ToString().Split('-')[0]);
            _myGuid = Guid.NewGuid();
        }

        public string CallMe()
        {
            _logger.LogCritical("PerSingleInstance - CallMe");
            return $"From PerSingleInstance ==> myGuid: {_myGuid}\n";
        }
    }
}