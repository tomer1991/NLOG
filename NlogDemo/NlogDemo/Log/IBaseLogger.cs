using Microsoft.AspNetCore.Mvc;
using NLog;

namespace NlogDemo.Log
{
    public interface IBaseLogger
    {

        //public Logger Logger { set { LogManager.GetCurrentClassLogger(); }  }
        //public Logger Logger { get { return LogManager.GetCurrentClassLogger(); } }
        public string Exception { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }

        void LogError(Exception ex);

       


    }
}
