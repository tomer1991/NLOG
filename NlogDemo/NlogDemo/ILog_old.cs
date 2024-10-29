namespace NlogDemo
{
    public interface ILog_old
    {
        public string Exception { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        void AddException();

    }
}
