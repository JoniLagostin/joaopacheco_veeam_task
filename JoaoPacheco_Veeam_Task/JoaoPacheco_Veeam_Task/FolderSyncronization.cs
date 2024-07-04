namespace JoaoPacheco_Veeam_Task
{
    public class FolderSyncronization
    {
        private readonly string _destinationPath;
        private readonly Logger _logger;
        private readonly string _sourcePath;

        public FolderSyncronization(string sourcePath, string destinationPath, Logger logger)
        {
            _sourcePath = sourcePath;
            _destinationPath = destinationPath;
            _logger = logger;
        }

        public void Sync()
        {
            _logger.Log("Sync started.");
        }
    }
}