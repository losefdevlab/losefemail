using LosefDevLab.LosefEmail.LosefIRMES;
class MAIN
{
    static int Main(string[] args)
    {
        IREMS Irems = new IREMS();
        if (args.Length == 1 && args[0] == "--version")
        {
            Console.WriteLine();
            Console.WriteLine("LosefEmail v1.0.r1.b1");
            Console.WriteLine("Use the 'LosefIRMES Kernel 1.0.r1.b1");
            Console.WriteLine("Copyright (c) 2025 LosefDevLab");
            Console.WriteLine("Sources:  https://github.com/losefdevlab/losefemail");
            Console.WriteLine();
        }
        if (args.Length == 2 && args[0] == "--send")
        {
            string[]? split;
            string? em = Irems.OpenSendEditor();
            if (args[1].Trim() != "")
            {
                split = args[1].Split('@', ':');
                Irems.IRSend(em, split);
            }
        }
        if (args.Length == 1 && args[0] == "--receive")
        {
            // Irems.ReceiveEM();
        }
        if (args.Length == 2 && args[0] == "--reg")
        {
            if (args[1].Trim() != "")
            {
                string[] split = args[1].Split('@', ':');
            }
            // Irems.WantReg(split);
        }
        if (args.Length == 1 && args[0] == "server")
        {
            Console.Write("LosefEmail Server Port(int port):");
            string? port = Console.ReadLine();
            //Irems.ServerBox server = new Irems.ServerBox(port);
            // server.Run();
        }
        return 0;
    }
}