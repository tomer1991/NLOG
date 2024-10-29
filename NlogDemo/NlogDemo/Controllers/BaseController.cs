using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using NlogDemo.Log;
using System.Diagnostics;

namespace NlogDemo.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseLogger Logger = new();
        protected void LogError(Exception ex)
        {
            Logger.EndDate = DateTime.Now;
            GlobalDiagnosticsContext.Set("request", Logger.Request);
            GlobalDiagnosticsContext.Set("StartDate", Logger.StartDate);
            GlobalDiagnosticsContext.Set("EndDate", Logger.EndDate);

            Logger.Logger.Error(ex, "An unexpected error occurred.");
        }

        protected IActionResult ExecuteActionAsync(Action action, string actionName)
        {
         

            try
            {
                //var result = action();
              
                var exception = $"Action {actionName} executed successfully in ms. Result: {JsonConvert.SerializeObject(action)}";

                LogError(new Exception(exception));
                 return Ok();
            }
            catch (Exception ex)
            {
             

                LogError(new Exception($@"{ex} error "));

                return Ok();
                // return StatusCode(500, "Internal Server Error");
            }
        }



        protected string GetGreeting()
        {
            return "Hello from BaseController!";
        }
    }
}
