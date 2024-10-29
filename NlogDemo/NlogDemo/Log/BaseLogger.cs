using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using NLog;
using System.Diagnostics;

namespace NlogDemo.Log
{


    public class BaseLogger : IBaseLogger
    {               
        public Logger Logger { get { return LogManager.GetCurrentClassLogger(); } }
        public string? Exception { get; set; }
        public string? Request { get; set; }
        public string? Response { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }       
        public void LogError(Exception ex)
        {
            EndDate = DateTime.Now;
            GlobalDiagnosticsContext.Set("request", Request);
            GlobalDiagnosticsContext.Set("StartDate", StartDate);
            GlobalDiagnosticsContext.Set("EndDate", EndDate);
            Logger.Error(ex, "An unexpected error occurred.");
        }





       
    }
}
