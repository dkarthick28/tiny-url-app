using Azure.Core;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace TinyUrl.AutoDelete
{
    public class AutoDeleteTinyUrl
    {
        private readonly ILogger _logger;

        public AutoDeleteTinyUrl(ILoggerFactory loggerFactory)
        { 
            _logger = loggerFactory.CreateLogger<AutoDeleteTinyUrl>();
        }

        [Function("AutoDeleteTinyUrl")]
        public async Task Run([TimerTrigger("*/61 * * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function started at: {DateTime.Now}");

            string? apiUrl = Environment.GetEnvironmentVariable("TargetApiUrl");
            string? sectretTOken = Environment.GetEnvironmentVariable("SecretToken");

            HttpClient httpClient = new HttpClient();
            var encodedSecret = Uri.EscapeDataString(sectretTOken);

            apiUrl = apiUrl + "?secretCode=" + encodedSecret;
            var response = await httpClient.DeleteAsync(apiUrl);
            if(response.IsSuccessStatusCode)
            _logger.LogInformation($"Timer Trigger Response : {response.Content.ToString()}");

            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
