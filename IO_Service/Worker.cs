using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace IO_Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client;
        private string JWTToken;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await client.PutAsync("http://localhost:5099/api/Buildings/AccountCoinsOnAllBuildings", null);
                
                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("The website is up: {StatusCode}", result.StatusCode);
                }
                else
                {
                    var loginInfo = await renewTokenAsync();
                    if (!loginInfo.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("There are issues signing in: {StatusCode}", loginInfo.StatusCode);
                    }
                }

                await Task.Delay(6000, stoppingToken);
            }
        }

        protected async Task<HttpResponseMessage> renewTokenAsync()
        {
            
            LoginClass loginClass = new LoginClass();
            loginClass.userName = "IOSERVICEv2";
            loginClass.password = "QazWsxEdc!432";
            var jsonLoginString = Newtonsoft.Json.JsonConvert.SerializeObject(loginClass);
            byte[] loginBytes = System.Text.Encoding.UTF8.GetBytes(jsonLoginString);
            var content = new ByteArrayContent(loginBytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await client.PostAsync("http://localhost:5099/api/Authenticate/login", content);
            var jsonString = await result.Content.ReadAsStringAsync();
            AuthorizeInformation temporaryObject = JsonConvert.DeserializeObject<AuthorizeInformation>(jsonString);
            client.BaseAddress = new Uri("http://localhost:5099/api/Buildings/AccountCoinsOnAllBuildings");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + temporaryObject.token);
            return result;
            
        }
    }
    
}