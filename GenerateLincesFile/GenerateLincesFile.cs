using System;
using AzureFunctionDocumentationAzure;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace GenerateLincesFile
{
    public static class GenerateLincesFile
    {
        [FunctionName("GenerateLincesFile")]
        public static void Run([QueueTrigger("Orders", Connection = "")]Order order, ILogger log)
        {
        }
    }
}
