using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boombang.Core
{
    class Commands
    {
        public static void ExecuteCommand(string command)
        {
            switch(command.ToLower())
            {
                case "commands":
                    Console.WriteLine("La lista de comandos es la siguiente:");
                    Console.WriteLine("  - info");
                    Console.WriteLine("  - release");
                    Console.WriteLine("  - exit");
                    Console.WriteLine("  - clear");

                    break;

                case "info":
                    Console.WriteLine("Boombang Server ha sido programado por:");
                    Console.WriteLine("  - Nevachana");
                    Console.WriteLine("  - Fuss");
                    break;

                case "release":
                    Console.WriteLine("Boombang se encuentra bajo la version (</> R1</>)");
                    break;

                case "exit":
                    Console.WriteLine("Boombang Server se cerrará proximamente.");
                    Environment.Exit(0);
                    break;

                case "clear":
                    Console.Clear();
                    break;
                default:
                    break;
            }
        }
    }
}
