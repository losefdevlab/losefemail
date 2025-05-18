using System;
using System.Diagnostics;
using System.Net.Sockets;
namespace LosefDevLab.LosefEmail.LosefIRMES
{
    // LosefIRMES 1.0.r1.b1
    class IREMS
    {
        StreamWriter? confsw;
        StreamReader? confrw = new StreamReader("config");
        StreamWriter? revemsw;
        StreamWriter? sendemsw;
        StreamReader? sendemrw = new StreamReader("sendem");
        Process p = new Process();
        public static string? emailstr;
        public IREMS()
        {
            if (!File.Exists("config"))
            {
                using (confsw = File.CreateText("config")) { }
            }
            if (!File.Exists("revem.json"))
            {
                using (revemsw = File.CreateText("revem.json")) { }
            }
            if (!File.Exists("sendem"))
            {
                using (sendemsw = File.CreateText("sendem")) { }
            }
            p.StartInfo.FileName = "vim";
            p.StartInfo.Arguments = "sendem";
        }
        public string? OpenSendEditor()
        {
            emailstr = ""?.Trim();
            Console.WriteLine("<VIM新手警告> 请注意!您即将在5秒之后进入您前所未用过的远古编辑器vim, 不阅读此操作您很难编辑消息，甚至连退出都不会");
            Console.WriteLine("请在之后进入vim，之后按下i开始编辑，编辑完了可以按esc，然后别管为什么退出编辑模式还要输入，只需输入:wq即可保存并退出");
            Thread.Sleep(5000);
            p.Start();
            p.WaitForExit();
            using (StreamReader? sendemrw = new StreamReader("sendem"))
            {
                string? em = ""?.Trim();
                string? line = ""?.Trim();
                while ((line = sendemrw.ReadLine()) != null)
                {
                    em += line + "\n";
                }
                return em;
            }

        }
        public void IRSend(string? em, string[]? split)
        {

            // 自行修改:IPV4&V6修改代码以任选一个
            try
            {
                using
                // IPV6
                // Socket socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
                // socket.Connect("127.0.0.1", 8080);

                // IPV4
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0", 8080);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void ReadAllLines(StreamReader streamReader)
        {
            while (!streamReader.EndOfStream)
            {
                string? line = streamReader.ReadLine();
                Console.WriteLine(line);
            }
        }
    }
}