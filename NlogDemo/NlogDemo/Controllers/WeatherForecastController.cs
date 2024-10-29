using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;

using System.Text.Json.Serialization;

namespace NlogDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {

        private const int V = 10;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            Logger.Request = "tomer request";

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
              return ExecuteActionAsync(() =>  WriteToLogTomer("tomer"), nameof(WriteToLogTomer));





            ////=======================================================
            //try
            //{
            //    WriteToLogTomer("tomer");
            //    return Ok();

            //}
            //catch (Exception ex)
            //{
            //    LogError(ex);
            //    throw;
            //}
        }
        [HttpPost(Name = "Hello")]
        public IActionResult Hello([FromBody] string name)
        {
            try
            {

                WriteToLogTomer("tomer");
                return Ok(name);

            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        private void WriteToLogTomer(string request)
        {
            WriteToLogTomer(request, V);
        }

        private void WriteToLogTomer(string request, int v)
        {
            // קוד שעלול לגרום לשגיאה
            int result = v / 0;
        }
    }
}
