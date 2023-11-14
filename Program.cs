using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace morskoy_boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Bot bot = new Bot();
            bool willPlay = true;

            while (willPlay)
            {
                while (true)
                {
                    user.Output(user.Field1);

                    user.Strike();

                    if (user.Win())
                    {
                        break;
                    }
                    bot.Strike();
                    if (bot.Win())
                    {
                        break;
                    }
                }
                Console.SetCursorPosition(30, 1);
                Console.Clear();
                Console.WriteLine("Игра окончена, но вы можете сыграть ещё одну партию. ");
                if ("yes".Equals(Console.ReadLine()) || "да".Equals(Console.ReadLine()))
                {
                    willPlay = false;
                }
                else
                {
                    Console.WriteLine("Не очень то и хотелось...");
                    Console.ReadKey();
                    break;
                }
            }
        }

        
    }
}
