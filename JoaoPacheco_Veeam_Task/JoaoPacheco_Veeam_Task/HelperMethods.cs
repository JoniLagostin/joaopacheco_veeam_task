using System.Security.Cryptography;

namespace JoaoPacheco_Veeam_Task
{
    public class HelperMethods
    {
        public static bool CompareMD5(string sourceFilePath, string destinationFilePath)
        {
            using var md5 = MD5.Create();
            using var sourceStream = File.OpenRead(sourceFilePath);
            using var destinationStream = File.OpenRead(destinationFilePath);

            var sourceHash = md5.ComputeHash(sourceStream);
            var destinationHash = md5.ComputeHash(destinationStream);

            return sourceHash.SequenceEqual(destinationHash);
        }
    }
}