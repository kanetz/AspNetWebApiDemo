using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.SelfHost;
using AspNetWebApiDemo;
using Newtonsoft.Json;
using Xunit;

namespace Test
{
    public class ValuesControllerTest : IDisposable
    {
        private const string BASE_ADDRESS = "http://localhost:9999";
        private HttpSelfHostServer selfHostServer;
        private HttpClient httpClient;

        public ValuesControllerTest()
        {
            StartSelfHostServer();
            CreateHttpClient();
        }

        private void StartSelfHostServer()
        {
            var configuration = new HttpSelfHostConfiguration(BASE_ADDRESS);
            WebApiConfig.Register(configuration);
            selfHostServer = new HttpSelfHostServer(configuration);
            selfHostServer.OpenAsync().Wait();
        }

        private void CreateHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public void Dispose()
        {
            selfHostServer.CloseAsync().Wait();
            selfHostServer.Dispose();
            httpClient.Dispose();
        }

        [Fact]
        public void should_return_200_ok_when_get_all_values()
        {
            var responseMessage = GetAllValues();
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        [Fact]
        public void should_return_predefined_values_when_get_all_values()
        {
            var responseMessage = GetAllValues();
            var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
            var values = JsonConvert.DeserializeObject<string[]>(responseBody);
            Assert.Equal(new[] { "value1", "value2" }, values);
        }

        private HttpResponseMessage GetAllValues()
        {
            var uri = string.Format("{0}/api/values", BASE_ADDRESS);
            return httpClient.GetAsync(uri).Result;
        }
    }
}
