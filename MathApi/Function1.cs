using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MathApi
{
    public static class Function1
    {
        [FunctionName("Add")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            log.LogInformation("Deepak - NTT >> maths addition");
            try
            {
                var num1 = req.Query["num1"];
                var num2 = req.Query["num2"];

                if (!string.IsNullOrEmpty(num1) && !string.IsNullOrEmpty(num2))
                {
                    var result = Convert.ToInt32(num1) + Convert.ToInt32(num2);
                    return new OkObjectResult(result);
                }
                else
                {
                    return new OkObjectResult("incorrect number supplied");
                }
            }
            catch (Exception ex)
            {

                return new OkObjectResult($"Server Error {ex.Message}");
            }
            
        }
    }
}
