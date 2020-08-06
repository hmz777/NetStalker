using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using ShellHelpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace NetStalker.MainLogic
{
    public static class Tools
    {
        /// <summary>
        /// Converts say 192.168.1.4 to 192.168.1.
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static string GetRootIp(IPAddress ipaddress)
        {
            string ipaddressstring = ipaddress.ToString();
            return ipaddressstring.Substring(0, ipaddressstring.LastIndexOf(".") + 1);
        }

        /// <summary>
        /// Converts a PhysicalAddress to colon delimited string like FF:FF:FF:FF:FF:FF
        /// </summary>
        /// <param name="physicaladdress"></param>
        /// <returns></returns>
        public static string GetMACString(PhysicalAddress physicaladdress)
        {
            string retval = "";
            for (int i = 0; i <= 5; i++)
                retval += physicaladdress.GetAddressBytes()[i].ToString("X2") + ":";
            return retval.Substring(0, retval.Length - 1);
        }

        /// <summary>
        /// Checks if both IPAddresses have the same root ip
        /// </summary>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <returns></returns>
        public static bool AreCompatibleIPs(IPAddress ip1, IPAddress ip2)
        {
            return (GetRootIp(ip1) == GetRootIp(ip2)) ? true : false;
        }

        /// <summary>
        /// Checks if both IPAddresses have the same root ip and the same subnet
        /// </summary>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool AreCompatibleIPs(IPAddress ip1, IPAddress ip2, int size)
        {
            return (GetRoot(ip1, size) == GetRoot(ip2, size));
        }

        /// <summary>
        /// Converts say 192.168.1.4 to 192.168.1.
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static string GetRootIp(string ipaddress)
        {
            return ipaddress.Substring(0, ipaddress.LastIndexOf(".") + 1);
        }

        /// <summary>
        /// Calculate the network size
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static string GetRoot(IPAddress IP, int Mask)
        {
            var ip = IP.ToString();
            switch (Mask)
            {
                case 1:
                    {
                        return ip.Substring(0, ip.LastIndexOf('.') + 1);
                    }

                case 2:
                    {
                        return ip.Substring(0, ip.IndexOf('.') + 5);
                    }

                case 3:
                    {
                        return ip.Substring(0, ip.IndexOf('.') + 1);
                    }
            }

            return "";
        }

        /// <summary>
        /// Return the Mac address of the selected network interface
        /// </summary>
        /// <param name="friendlyname"></param>
        /// <returns></returns>
        public static PhysicalAddress GetLocalMac(string FriendlyName)
        {
            if (string.IsNullOrEmpty(FriendlyName))
                throw new NullReferenceException("\"FriendlyName\" is null");

            foreach (var networkinterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkinterface.Name == FriendlyName)
                {
                    return networkinterface.GetPhysicalAddress();
                }
            }

            return default;
        }

        /// <summary>
        /// Return the gateway IPAddress (V4) of the selected network interface
        /// </summary>
        /// <param name="friendlyname">The friendly name of the selected network interface</param>
        /// <returns>Returns the gateway IPAddress of the selected network interface's</returns>
        public static IPAddress GetGatewayIP(string FriendlyName)
        {
            if (string.IsNullOrEmpty(FriendlyName))
                throw new NullReferenceException("\"FriendlyName\" is null");

            foreach (var networkinterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkinterface.Name == FriendlyName)
                {
                    foreach (var gateway in networkinterface.GetIPProperties().GatewayAddresses)
                    {
                        if (gateway.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) //IPV4
                            return gateway.Address;
                    }
                }
            }

            return default;
        }

        /// <summary>
        /// Check if a shortcut is already created, if not then create a new one (Necessary for the toast notification service).
        /// </summary>
        /// <returns></returns>
        public static bool TryCreateShortcut()
        {
            String shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\NetStalker.lnk";
            if (!File.Exists(shortcutPath))
            {
                InstallShortcut(shortcutPath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create a start shortcut for the app and set the AppUserModelId and ToastActivatorCLSID in the shortcut property store (Necessary for the toast notification service).
        /// </summary>
        /// <param name="shortcutPath"></param>
        private static void InstallShortcut(String shortcutPath)
        {
            // Find the path to the current executable
            String exePath = Process.GetCurrentProcess().MainModule.FileName;
            IShellLinkW newShortcut = (IShellLinkW)new CShellLink();

            // Create a shortcut to the exe
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetPath(exePath));
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetArguments(""));

            // Open the shortcut property store, set the AppUserModelId property
            IPropertyStore newShortcutProperties = (IPropertyStore)newShortcut;

            using (MS.WindowsAPICodePack.Internal.PropVariant appId = new MS.WindowsAPICodePack.Internal.PropVariant(AppConfiguration.APP_ID))
            {
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.SetValue(SystemProperties.System.AppUserModel.ID, appId));
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.Commit());
            }

            using (MS.WindowsAPICodePack.Internal.PropVariant guid = new MS.WindowsAPICodePack.Internal.PropVariant(AppConfiguration.Guid))
            {
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.SetValue(SystemProperties.System.AppUserModel.ToastActivatorCLSID, guid));
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.Commit());
            }

            // Commit the shortcut to disk
            ShellHelpers.IPersistFile newShortcutSave = (ShellHelpers.IPersistFile)newShortcut;

            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutSave.Save(shortcutPath, true));
        }

        /// <summary>
        /// Returns the broadcast address for the current network.
        /// </summary>
        /// <remarks>
        /// This is used to determine the address that is used to broadcast the arp packets across the network.
        /// </remarks>
        /// <param name="LocalIp"></param>
        /// <param name="SubnetMask"></param>
        public static IPAddress GetBroadcastAddress(IPAddress LocalIp, string SubnetMask)
        {
            var BinaryIp = LocalIp.GetAddressBytes().Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
            var BinaryMask = SubnetMask.Split('.').Select(x => Convert.ToString(Int32.Parse(x), 2).PadLeft(8, '0')).ToArray();
            var BinaryNetworkAddress = new Int32[4]; //Network address
            var BinaryBroadcastAddress = new Int32[4]; //Broadcast address


            for (int i = 0; i < 4; i++)
            {
                BinaryNetworkAddress[i] = (Convert.ToInt32(BinaryIp[i], 2)) & (Convert.ToInt32(BinaryMask[i], 2));
            }

            for (int i = 0; i < 4; i++)
            {
                BinaryBroadcastAddress[i] = (BinaryNetworkAddress[i]) ^ (~Convert.ToInt32(BinaryMask[i], 2) & 0x000000FF);
            }

            return IPAddress.Parse(string.Join(".", BinaryBroadcastAddress.Select(x => x.ToString())));
        }

        /// <summary>
        /// This method is used to decrypt the password (if set) for validation.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DecryptText(string input, string password)
        {
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        /// <summary>
        /// A helper method that contains the logic for the password encryption algorithm.
        /// </summary>
        /// <param name="bytesToBeDecrypted"></param>
        /// <param name="passwordBytes"></param>
        /// <returns></returns>
        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            byte[] saltBytes = new byte[] { 19, 9, 94, 1, 94, 9, 19, 2 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        /// <summary>
        /// This method is used to encrypt the password (if set).
        /// </summary>
        /// <param name="input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptText(string input, string password)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        /// <summary>
        /// A helper method that contains the logic for the password decryption algorithm.
        /// </summary>
        /// <param name="bytesToBeEncrypted"></param>
        /// <param name="passwordBytes"></param>
        /// <returns></returns>
        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;


            byte[] saltBytes = new byte[] { 19, 9, 94, 1, 94, 9, 19, 2 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
    }
}
