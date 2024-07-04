namespace JoaoPacheco_Veeam_Task
{
    public class Logger
    {
        /// <summary>
        /// Instance that logs messages to the console and to a log file
        /// </summary>
        /// <param name="logFilePath"></param>
        public Logger(string logFilePath)
        {
            LogFilePath = logFilePath;
        }

        public string LogFilePath { get; private set; }

        /// <summary>
        /// Logs a message to the console and to the log file
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public void Log(string message)
        {
            string logMessage = DateTime.Now.ToString("HH:mm:ss") + ": " + message;
            Console.WriteLine(logMessage);
            File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
        }
    }
}