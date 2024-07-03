namespace JoaoPacheco_Veeam_Task
{
    public class Logger
    {
        public Logger(string logFilePath)
        {
            LogFilePath = logFilePath;
        }

        public string LogFilePath { get; private set; }

        public void Log(string message)
        {
            string logMessage = DateTime.Now.ToString("HH:mm:ss") + ": " + message;
            Console.WriteLine(logMessage);
            File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
        }
    }
}