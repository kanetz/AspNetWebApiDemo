using System;
using System.Net.Http;
using System.Web.Http.SelfHost;
using AspNetWebApiDemo;

namespace Test
{
    public class UsingSelfHostServer : IDisposable
    {
        protected const string BaseAddress = "http://localhost:9999";
        private readonly HttpSelfHostServer selfHostServer;
        private readonly HttpClient httpClient;

        protected UsingSelfHostServer()
        {
            selfHostServer = StartSelfHostServer();
            httpClient = CreateHttpClient();
        }

        protected HttpClient HttpClient { get { return httpClient; } }

        private static HttpSelfHostServer StartSelfHostServer()
        {
            var configuration = new HttpSelfHostConfiguration(BaseAddress);
            WebApiConfig.Register(configuration);
            var selfHostServer = new HttpSelfHostServer(configuration);
            selfHostServer.OpenAsync().Wait();
            return selfHostServer;
        }

        private static HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpClient;
        }

        public void Dispose()
        {
            selfHostServer.CloseAsync().Wait();
            selfHostServer.Dispose();
            httpClient.Dispose();
        }
    }
}