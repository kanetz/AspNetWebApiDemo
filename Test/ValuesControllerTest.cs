using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace Test
{
    public class ValuesControllerTest : UsingSelfHostServer
    {
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
            var uri = string.Format("{0}/api/values", BaseAddress);
            return HttpClient.GetAsync(uri).Result;
        }
    }
}
