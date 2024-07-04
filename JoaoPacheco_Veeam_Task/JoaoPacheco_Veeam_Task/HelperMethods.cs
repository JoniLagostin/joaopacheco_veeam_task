using System.Security.Cryptography;

namespace JoaoPacheco_Veeam_Task
{
    public class HelperMethods
    {
        /// <summary>
        /// Compares the MD5 hash of two files
        /// </summary>
        /// <param name="filePath">Path of file to be compared</param>
        /// <param name="anotherFilePath">Path of the file to be compared to</param>
        /// <returns>true if hash is equal, false otherwise </returns>
        public static bool CompareMD5(string filePath, string anotherFilePath)
        {
            using var md5 = MD5.Create();
            using var sourceStream = File.OpenRead(filePath);
            using var destinationStream = File.OpenRead(anotherFilePath);

            var sourceHash = md5.ComputeHash(sourceStream);
            var destinationHash = md5.ComputeHash(destinationStream);

            return sourceHash.SequenceEqual(destinationHash);
        }
    }
}