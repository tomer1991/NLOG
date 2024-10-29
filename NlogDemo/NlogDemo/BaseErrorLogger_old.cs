using NLog;

namespace NlogDemo
{
    public  class BaseErrorLogger_old
    {
        private  readonly Logger logger = LogManager.GetCurrentClassLogger();
        public  string Exception { get; set; }
        public  string Request { get; set; }
        public  string Response { get; set; }
        public  DateTime? StartDate  { get; set; }
        public  DateTime EndDate { get; set; }
        public BaseErrorLogger_old()
        {
            StartDate = DateTime.Now;
            Exception=string.Empty;
            Request = string.Empty;
            Response = string.Empty;
        }

        public  void LogError(Exception ex)
        {

           

            EndDate = DateTime.Now;            
            NLog.GlobalDiagnosticsContext.Set("request", Request);
            NLog.GlobalDiagnosticsContext.Set("StartDate", StartDate);
            NLog.GlobalDiagnosticsContext.Set("EndDate", EndDate);

            logger.Error(ex, "An unexpected error occurred.");
        }
    }
}
