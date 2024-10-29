namespace NlogDemo
{
    public class Log_old : ILog_old
    {
        public string Exception { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Request { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Response { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddException()
        {
            throw new NotImplementedException();
        }
    }
}
