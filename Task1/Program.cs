using Task1;

LogEntry logEntry1 = new LogEntry(DateTime.Now, "DASD", LogEntry.LogLevel.Warning);
LogEntry logEntry2 = new LogEntry(DateTime.Parse("22.05.2018"), "asw", LogEntry.LogLevel.Error);
LogEntry logEntry3 = new LogEntry("1234", LogEntry.LogLevel.Info);
LogEntry logEntry4 = new LogEntry(DateTime.Now, "789654", LogEntry.LogLevel.Error);
LogEntry logEntry5 = new LogEntry(DateTime.Parse("22.05.2018"), "Dasd", LogEntry.LogLevel.Warning);
LogEntry logEntry6 = new LogEntry("5678", LogEntry.LogLevel.Info);
LogEntry[] logs = { logEntry1, logEntry2, logEntry3, logEntry4, logEntry5, logEntry6 };

LogEntry[] filteredLogs = (LogEntry[])LogProcessor.FilterByLevel(logs, LogEntry.LogLevel.Warning);
foreach (LogEntry log in filteredLogs)
{
    Console.WriteLine($"{log.Message}  {log.level}  {log.Timestamp}");
}
Console.WriteLine("----------------------------------------------------");

LogEntry[] filteredByTime = (LogEntry[])LogProcessor.FindRecentLogs(logs, DateTime.Parse("22.05.2018"));
foreach (LogEntry log in filteredByTime)
{
    Console.WriteLine($"{log.Message}  {log.level}  {log.Timestamp}");
}
Console.WriteLine("----------------------------------------------------");

var groupedByLevel = LogProcessor.GroupByLevel(logs);
foreach (var log in groupedByLevel)
{
    Console.WriteLine($"{log.Key}  {log.Value}");
}
Console.WriteLine("----------------------------------------------------");

var topLogs = LogProcessor.FindTopLogs(logs, "D", 1);
foreach (LogEntry log in topLogs)
{
    Console.WriteLine($"{log.Message}  {log.level}  {log.Timestamp}");
}
Console.WriteLine("----------------------------------------------------");

LogProcessor.ErrorOccurred += ThrowMessage;
LogProcessor.CheckErrors(logs); ;

Console.WriteLine("----------------------------------------------------");

void ThrowMessage(string message) => Console.WriteLine(message);