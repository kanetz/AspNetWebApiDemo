using System;
using System.Net;
using System.Net.Http;
using AspNetWebApiDemo.Models;
using Newtonsoft.Json;
using Xunit;

namespace Test
{
    public class CoursesControllerTest : UsingSelfHostServer
    {
        [Fact]
        public void should_return_200_ok_when_get_all_courses()
        {
            var responseMessage = GetAllCourses();
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        [Fact]
        public void should_return_predefined_values_when_get_all_values()
        {
            var responseMessage = GetAllCourses();
            var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
            var courses = JsonConvert.DeserializeObject<Course[]>(responseBody);
            Assert.Equal(courses.Length, 2);
            Assert.Equal(new Course("C#"), courses[0]);
            Assert.Equal(new Course("JavaScript"), courses[1]);
        }

        private HttpResponseMessage GetAllCourses()
        {
            var uri = string.Format("{0}", BaseAddress);
            return HttpClient.GetAsync(uri).Result;
        }
    }
}
