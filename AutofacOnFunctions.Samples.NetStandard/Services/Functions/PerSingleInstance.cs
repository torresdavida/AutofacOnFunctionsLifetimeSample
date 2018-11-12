using Microsoft.Extensions.Logging;
using System;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    public class PerSingleInstance : IPerSingleInstance
    {
        private readonly ILogger _logger;
        private readonly string _myGuid;

        public PerSingleInstance(ILogger logger)
        {
            _myGuid = Guid.NewGuid().ToString().Split('-')[0];
            _logger = logger;
            _logger.LogCritical($"PerSingleInstance - ctor - {_myGuid}");
        }

        public string CallMe()
        {
            _logger.LogCritical($"PerSingleInstance - CallMe - {_myGuid}");
            return "";
        }
    }
}