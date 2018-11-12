using AutofacOnFunctions.Services.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest request
            , [Inject]
            ILogger logger
            , [Inject]
            ITestIt testIt
        )
        {
            logger.LogInformation("<<<<Start Trigger>>>>>");
            testIt.CallMe();
            return new OkObjectResult($"Dependency injection sample returns");
        }
    }
}