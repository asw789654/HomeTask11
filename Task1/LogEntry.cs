namespace Task1
{
    public class LogEntry
    {
        private DateTime _timestamp;
        public enum LogLevel { Info, Warning, Error };
        private string _message = string.Empty;
        public LogLevel level;
        public LogEntry(DateTime timestamp, string messege, LogLevel level)
        {
            this.Timestamp = timestamp;
            this.Message = messege;
            this.level = level;
        }

        public LogEntry(string messege, LogLevel level)
        {
            this.Timestamp = DateTime.Now;
            this.Message = messege;
            this.level = level;
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
