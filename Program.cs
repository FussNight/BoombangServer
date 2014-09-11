using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boombang.Core;
using Boombang;
namespace Boombang
{
    class Program
    {
        static void Main(string[] args)
        {
            bool consoleCommandEnabled = true;
            Console.Title = "Boombang Server - Start ";
            Boombang.Start();
            while (consoleCommandEnabled)
            {
               
                
                   
                    string Command = Console.ReadLine();
                    Commands.ExecuteCommand(Command);
                }
            }
        }
    }
