﻿namespace JoaoPacheco_Veeam_Task
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

        public void SyncFiles()
        {
            // Copy files from source to destination
            // Updates files if they have different MD5 hash
            foreach (var sourceFile in Directory.GetFiles(_sourcePath))
            {
                var destinationFile = Path.Combine(_destinationPath, Path.GetFileName(sourceFile));

                if (!File.Exists(destinationFile))
                {
                    File.Copy(sourceFile, destinationFile);
                    _logger.Log($"File copied: {sourceFile} -> {destinationFile}");
                }
                else if (!HelperMethods.CompareMD5(sourceFile, destinationFile))
                {
                    File.Copy(sourceFile, destinationFile, true);
                    _logger.Log($"File updated: {sourceFile} -> {destinationFile}");
                }
            }

            // Delete files from destination that do not exist in source
            foreach (var destinationFile in Directory.GetFiles(_destinationPath))
            {
                var sourceFile = Path.Combine(_sourcePath, Path.GetFileName(destinationFile));

                if (!File.Exists(sourceFile))
                {
                    File.Delete(destinationFile);
                    _logger.Log($"File deleted: {destinationFile}");
                }
            }
        }
    }
}