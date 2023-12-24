using static Task1.LogEntry;

namespace Task1
{
    public class LogProcessor
    {
        public delegate void ErrorHandler(string message);
        public static event ErrorHandler? ErrorOccurred;

        public static LogEntry[] FilterByLevel(LogEntry[] logs, LogLevel level)
        {
            var filteredLogs = logs.Where(x => x.level == level);
            return filteredLogs.ToArray();
        }

        public static LogEntry[] FindRecentLogs(LogEntry[] logs, DateTime since)
        {
            var filteredLogs = logs.Where(x => x.Timestamp > since);
            return filteredLogs.ToArray();
        }

        public static Dictionary<LogLevel, int> GroupByLevel(LogEntry[] logs)
        {
            Dictionary<LogLevel, int> result = new Dictionary<LogLevel, int>();
            var filteredLogs = logs.GroupBy(x => x.level).Select(x => new { Log = x.Key, Count = x.Count() });
            foreach (var log in filteredLogs)
            {
                result.Add(log.Log, log.Count);
            }
            return result;
        }

        public static LogEntry[] FindTopLogs(LogEntry[] logs, string keyword, int count)
        {

            var result = logs.Where(obj => obj.Message.Contains(keyword)).OrderBy(message => message.Timestamp).Take(count).ToArray();
            return result;
        }

        public static List<string> CheckErrors(LogEntry[] logs)
        {
            List<string> errors = new List<string>();
            foreach (var log in logs)
            {

                if (log.level.Equals(LogLevel.Error))
                {
                    ErrorOccurred?.Invoke(log.Message);
                    errors.Add(log.Message);
                }
            }
            return errors;
        }
    }
}
