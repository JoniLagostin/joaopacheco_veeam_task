namespace JoaoPacheco_Veeam_Task
{
    internal class Program
    {
        private static FolderSyncronization? _folderSyncronization;
        private static Logger? _logger;

        /// <summary>
        /// Main method that starts the application
        /// </summary>
        /// <param name="args">
        /// 1st Argument: Source directory path
        /// 2nd Argument: Destination directory path
        /// 3rd Argument: Sync interval in seconds
        /// 4th Argument: Log file path
        /// </param>
        static void Main(string[] args)
        {
            if (!ValidateArgs(args))
                return;

            var sourcePath = args[0];
            var destinationPath = args[1];
            var syncInterval = double.Parse(args[2]);
            var logFilePath = args[3];

            // Sets up Logger and FolderSyncronization instances
            _logger = new Logger(logFilePath);
            _folderSyncronization = new FolderSyncronization(sourcePath, destinationPath, _logger);

            // Set up Timer, on elapsed, triggers event to sync files
            var timer = new System.Timers.Timer();
            timer.Elapsed += (sender, e) => _folderSyncronization.SyncFiles();
            timer.Interval = (syncInterval * 1000);
            timer.Enabled = true;
            timer.AutoReset = true;

            _logger.Log("Application started.");
            Console.WriteLine("Press any key to stop the application.");
            Console.ReadLine();
            _logger.Log("Application stopped.");
        }

        /// <summary>
        /// Validates the arguments provided to the application
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="FormatException"></exception>
        private static bool ValidateArgs(string[] args)
        {
            try
            {
                if (args.Length < 4)
                {
                    throw new ArgumentException("Not enough arguments provided. Expected: sourcePath, destinationPath, syncInterval, logFilePath.");
                }

                var sourcePath = args[0];
                if (!Directory.Exists(sourcePath))
                {
                    throw new DirectoryNotFoundException($"Source directory does not exist: {sourcePath}");
                }

                var destinationPath = args[1];
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                    Console.WriteLine($"Destination directory created: {destinationPath}");
                }

                var syncIntervalSuccess = double.TryParse(args[2], out double syncInterval);
                if (!syncIntervalSuccess)
                {
                    throw new FormatException($"Invalid sync interval: {args[2]}");
                }

                var logFilePath = args[3];
                if (!File.Exists(logFilePath))
                {
                    File.Create(logFilePath).Close();
                    Console.WriteLine($"Log file created: {logFilePath}");
                }
                else
                {
                    File.WriteAllText(logFilePath, string.Empty);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}