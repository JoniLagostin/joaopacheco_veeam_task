namespace JoaoPacheco_Veeam_Task
{
    internal class Program
    {
        private static Logger _logger;

        static void Main(string[] args)
        {
            if (!ValidateArgs(args))
                return;

            _logger = new Logger(args[3]);
        }

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