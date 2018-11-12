using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunForTheRoses.Models;
using RunForTheRoses.Repository;

namespace RunForTheRoses
{
    public static class HorseBetLoader
    {
        private static string ErrorMessage = "File does not exits. Pick another option";
        public static HorseBet GetHorseBetFromFile()
        {
            HorseBet lastBet = null;
            while (lastBet == null)
            {
                Console.WriteLine("How do you want to load the last Horse Bet? Press 1 for Plain Text. Press 2 for Json.");
                var type = Console.ReadKey().KeyChar;

                if (type == '1')
                {
                    var repo = new PlainTextRepository(Program.HorseBetPathBase);
                    lastBet = repo.Load();
                    if(lastBet == null)
                        Console.WriteLine(ErrorMessage);
                }
                else //will read the json file
                {
                    var repo = new JsonRepository(Program.HorseBetPathBase);
                    lastBet = repo.Load();

                    if(lastBet == null)
                        Console.WriteLine(ErrorMessage);
                }
            }

            return lastBet;
        }
    }
}
