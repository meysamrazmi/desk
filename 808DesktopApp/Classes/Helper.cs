using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _808DesktopApp.Classes
{
    public class Helper
    {
        public enum FileType { Video, PDF, Other }
        private static string sourceFilePath = "sourceFilePath";
        public static string extractFilePath;
        private static bool allowSaveImage = true;
        private static Random random = new Random();
        private static int length = 6;
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private static SymmetricAlgorithm _algorithm = new RijndaelManaged();
        public static byte[] DecryptData(byte[] cryptoData, string password)
        {
            try
            {
                GetKey(password);

                ICryptoTransform decryptor = _algorithm.CreateDecryptor();

                byte[] data = decryptor.TransformFinalBlock(cryptoData, 0, cryptoData.Length);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private static void GetKey(string password)
        {
            byte[] salt = new byte[8];

            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            int length = Math.Min(passwordBytes.Length, salt.Length);

            for (int i = 0; i < length; i++)
                salt[i] = passwordBytes[i];

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt);

            _algorithm.Key = key.GetBytes(_algorithm.KeySize / 8);
            _algorithm.IV = key.GetBytes(_algorithm.BlockSize / 8);

        }
        public static FileType DetectFileType(string name)
        {
            var extVideo = new List<string> { ".mp4", ".avi", ".mov", ".mkv" };
            var pdf = new List<string> { ".pdf" };
            var extension = System.IO.Path.GetExtension(name);
            if (extVideo.Any(c => c == extension))
                return FileType.Video;
            else if (pdf.Any(c => c == extension))
                return FileType.PDF;
            else
                return FileType.Other;
        }


        public static void CreatePath()
        {
            if (!Directory.Exists(sourceFilePath))
                Directory.CreateDirectory(sourceFilePath);
            if (!Directory.Exists(extractFilePath))
                Directory.CreateDirectory(extractFilePath);
        }
        public static string GetFileNameinDirectory(string fileName)
        {
            return Path.Combine(sourceFilePath, fileName);
        }
        public static string ExtractFilePath(string fileName)
        {
            return Path.Combine(extractFilePath, fileName);
        }
        public static string FindFileInDrive(string fileName, string drive)
        {
            string findPath = null;
            var files = Directory.GetFiles(drive);
            var file = files.FirstOrDefault(c => c.EndsWith(fileName));
            if (file != null)
                return file;
            var directoreies = Directory.GetDirectories(drive);

            foreach (var directory in directoreies)
            {
                findPath = FindFileInDrive(fileName, directory);
                if (findPath != null)
                    return findPath;
            }
            return findPath;
        }
        private static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
        }
        public static bool CopyFileToSource(string fromPath)
        {
            try
            {
                var source = new DirectoryInfo(fromPath);
                var target = new DirectoryInfo(sourceFilePath);
                CopyFilesRecursively(source, target);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        private const int Keysize = 256;
        private const int DerivationIterations = 1000;
        public static string Encrypt(string plainText, string passPhrase)
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }
        public static string Decrypt(string cipherText, string passPhrase)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }


        public static string saveImage(string url)
        {
            if (!allowSaveImage)
                return null;

            var link = url.Remove(url.IndexOf("?"));
            link = Uri.UnescapeDataString(link);
            if (System.IO.Path.GetExtension(link).Length < 1)
                return null;

            var directory = GetFileNameinDirectory("images");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var fileName = Path.Combine(directory, System.IO.Path.GetFileName(link));
            if (!System.IO.File.Exists(fileName))
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri(url),
                        // Param2 = Path to save
                        fileName
                    );
                }
            }

            return fileName;
        }
        public static string getFileSize(int fileSize)
        {
            var num = fileSize / 1024.0; // kb
            num = num / 1024.0; // mb
            return Math.Round(num, 2) + " مگابایت ";
        }

        public static string getCPUSerial()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return cpuInfo;
        }
        public static string getCPUName()
        {
            ManagementClass CPUN = new ManagementClass("Win32_Processor");
            ManagementObjectCollection CPU_N = CPUN.GetInstances();
            string outcome = String.Empty;
            foreach (ManagementObject CPU in CPU_N)
            {
                outcome = CPU.Properties["name"].Value.ToString();
                break;
            }
            outcome = outcome.Trim();
            char[] a = outcome.ToArray();
            string s = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].ToString() != " " || a[i + 1].ToString() != " ")
                {
                    s = s + a[i].ToString();
                }
            }
            return s.Trim();
        }
        public static string getMainbord()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Product").ToString().Trim();
                }
                catch { }
            }
            return "No Detected";
        }
        public static string getHDDSerial()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
            var result = string.Empty;
            foreach (ManagementObject wmi_HD in searcher.Get())
                if (wmi_HD["SerialNumber"] != null)
                    result += wmi_HD["SerialNumber"].ToString().Trim() + ",";
            return result == string.Empty ? "No Detected": result;
        }

    }
}
