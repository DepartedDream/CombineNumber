using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;

namespace CombineNumber
{
    static class Program
    {
        public static Type CurrentFormType { get; set; }
        public static List<Player> Top10PlayerList { get; set; }
        public static string CurrentPlayerName { get; set; }
        public static GameDifficulty CurrentGameDifficulty { get; set; }
        private static string key = "17412911";
        private static string iv = "1sfrgd;80jkmlaasdo0;ed6tkt7jr6dfikj9p[o789l7y8lo76y8ok";

        [STAThread]
        static void Main()
        {
            CurrentFormType = typeof(MenuForm);
            Top10PlayerList = new List<Player>();
            CurrentGameDifficulty = GameDifficulty.normal;
            CurrentPlayerName = "player";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitialPlayerFile();
            ReadPlayerFile();
            while (true)
            {
                if (CurrentFormType != null)
                {
                    Application.Run((Form)Activator.CreateInstance(CurrentFormType));
                }
                else
                {
                    break;
                }
            }
            WritePlayerFile();
            Application.Exit();
        }

        public static void InitialPlayerFile()
        {
            string playerFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}PlayerFile";
            if (!File.Exists(playerFilePath))
            {
                StreamWriter streamWriter = new FileInfo(playerFilePath).CreateText();
                for (int i = 0; i < 10; i++)
                {
                    streamWriter.WriteLine(DESEncrypt("player-0"));
                }
                streamWriter.Dispose();
            }
        }

        public static void ReadPlayerFile()
        {
            string playerFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}PlayerFile";
            StreamReader streamReader = new FileInfo(playerFilePath).OpenText();
            for (int i = 0; i < 10; i++)
            {
                string[] value = DESDecrypt(streamReader.ReadLine()).Split('-');
                Top10PlayerList.Add(new Player(value[0], Int32.Parse(value[1])));
            }
            streamReader.Dispose();
        }

        public static void WritePlayerFile()
        {
            string playerFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}PlayerFile";
            StreamWriter streamWriter = new FileInfo(playerFilePath).CreateText();
            for (int i = 0; i < 10; i++)
            {
                streamWriter.WriteLine(DESEncrypt($"{Top10PlayerList[i].Name}-{ Top10PlayerList[i].Score}"));
            }
            streamWriter.Dispose();
        }

        public static string DESEncrypt(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        public static string DESDecrypt(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
    }
}
