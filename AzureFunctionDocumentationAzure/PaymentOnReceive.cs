using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AzureFunctionDocumentationAzure
{
    public static class PaymentOnReceive
    {
        [FunctionName("PaymentOnReceive")]
        public static async Task<ActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] Order order,
            [Queue("orders")] IAsyncCollector<Order> orderQueue,
            //[Queue("orders", Connection ="myappsettings")] IAsyncCollector<Order> orderQueue, if we specify variable name for connection
            ILogger log)
        {
            log.LogInformation("Order Received");

            //Add to queue
            await orderQueue.AddAsync(order);

            return new OkObjectResult("Thank you for your purchase");
        }
    }

    public class Order
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
