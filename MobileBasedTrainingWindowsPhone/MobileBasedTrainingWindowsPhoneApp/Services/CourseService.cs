using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileBasedTrainingWindowsPhoneApp.Models;
using Newtonsoft.Json;

namespace MobileBasedTrainingWindowsPhoneApp.Services
{
    public class CourseService
    {
        public async Task<List<Course>> GetCoursesAsync()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(
                    "http://mobileemergencytraining.azurewebsites.net/",
                    UriKind.Absolute)
            };
            string json = await client.GetStringAsync("api/courseapi");
            return JsonConvert.DeserializeObject<List<Course>>(json);
        }
    }
}
