using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boombang.Core;
using Boombang.MySQL;
using Boombang.Networking;
using System.Net;

namespace Boombang
{
    class Boombang
    {
        private static SocketSystem SocketSystem;
        private static MySQLManager Mysql;
       
        public static void Start()
        {

            Console.WriteLine(@"______                       _                       ");
            Console.WriteLine(@"| ___ \                     | |                      ");
            Console.WriteLine(@"| |_/ / ___   ___  _ __ ___ | |__   __ _ _ __   __ _ ");
            Console.WriteLine(@"| ___ \/ _ \ / _ \| '_ ` _ \| '_ \ / _` | '_ \ / _` |");
            Console.WriteLine(@"| |_/ / (_) | (_) | | | | | | |_) | (_| | | | | (_| |");
            Console.WriteLine(@"\____/ \___/ \___/|_| |_| |_|_.__/ \__,_|_| |_|\__, |");
            Console.WriteLine(@"                                                __/ |");
            Console.WriteLine(@"                                               |___/ ");
            Console.WriteLine("         This is made by Fuss and Nevachana");
            Console.WriteLine("  </> Usa los comandos escribiendo commands </> ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Mysql = new MySQLManager("localhost", 3306, "root", "123", "test", true, 5, 9999);

                          
            

            SocketSystem = new SocketSystem();
            SocketSystem.ConstructSocket(IPAddress.Parse("127.0.0.1"), 2001, 10);
            SocketSystem.ConstructPooling(10000);
           
            
        }
    }
}
