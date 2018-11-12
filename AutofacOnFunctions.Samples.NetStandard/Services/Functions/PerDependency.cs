using Autofac;
using Microsoft.Extensions.Logging;
using System;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    public class PerDependency : IPerDependency
    {
        private readonly string _myGuid;
        private readonly ILogger _logger;
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IPerLifetimeScope _perLifetimeScope;

        public PerDependency
        (
            ILogger logger
            , ILifetimeScope lifetimeScope
            , IPerLifetimeScope perLifetimeScope
        )
        {
            _myGuid = Guid.NewGuid().ToString().Split('-')[0];
            _logger = logger;
            _lifetimeScope = lifetimeScope;
            _perLifetimeScope = perLifetimeScope;
            _logger.LogError($"PerDependency - ctor - {_myGuid}");
        }

        public string CallMe()
        {
            _logger.LogError($"PerDependency - CallMe - {_myGuid}");
            _perLifetimeScope.CallMe();
            return "";
        }
    }
}