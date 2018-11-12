

using Autofac;
using Microsoft.Extensions.Logging;
using System;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    internal class TestIt : ITestIt
    {
        private readonly ILogger _logger;
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IPerSingleInstance _perSingleInstance;
        private IPerDependency _perDependency;
        private readonly IPerLifetimeScope _perLifetimeScope1;
        private IPerLifetimeScope _perLifetimeScope2;


        public TestIt(
            ILogger logger
            , ILifetimeScope lifetimeScope
            , IPerSingleInstance perSingleInstance
        , IPerLifetimeScope perLifetimeScope1
        )
        {
            _logger = logger;
            _lifetimeScope = lifetimeScope;
            _logger.LogInformation("TestIt - ctor - " + Guid.NewGuid().ToString().Split('-')[0]);
            _perLifetimeScope1 = perLifetimeScope1;
            _perSingleInstance = perSingleInstance;
        }

        public string CallMe()
        {
            _logger.LogInformation("TestIt - CallMe");

            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                _perDependency = scope.Resolve<IPerDependency>();
                _perLifetimeScope2 = scope.Resolve<IPerLifetimeScope>();

                _logger.LogInformation($">>>>>Start Request<<<<<");
                _logger.LogInformation($"{_perSingleInstance.CallMe()}");
                _logger.LogInformation($"_perLifetimeScope1^^^{_perLifetimeScope1.CallMe()}");
                _logger.LogInformation($"_perLifetimeScope2^^^{_perLifetimeScope2.CallMe()}");
                _logger.LogInformation($"{_perDependency.CallMe()}");
            }
            return "";
        }
    }
}
