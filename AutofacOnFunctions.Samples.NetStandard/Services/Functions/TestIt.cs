

using System;
using System.Text;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    internal class TestIt : ITestIt
    {
        private readonly ILogger _logger;
        private readonly IPerSingleInstance _perSingleInstance;
        private readonly IPerDependency _perDependency;
        private readonly IPerLifetimeScope _perLifetimeScope;


        public TestIt(
            ILogger logger
            , IPerSingleInstance perSingleInstance
            , IPerLifetimeScope perLifetimeScope
            , IPerDependency perDependency
        )
        {
            _logger = logger;
            _logger.LogWarning("TestIt - " + Guid.NewGuid().ToString().Split('-')[0]);
            _perDependency = perDependency;
            _perLifetimeScope = perLifetimeScope;
            _perSingleInstance = perSingleInstance;

        }

        public string CallMe()
        {
            _logger.LogCritical("TestIt - CallMe");
            StringBuilder called = new StringBuilder();
            called.Append($"\n\nTestIt\n\n");
            called.Append($"{_perDependency.CallMe()}\n");
            called.Append($"{_perLifetimeScope.CallMe()}\n");
            called.Append($"{_perSingleInstance.CallMe()}\n");
            return called.ToString();
        }
    }
}
