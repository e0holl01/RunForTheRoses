using System;
using System.Collections.Generic;
using System.Linq;
using RunForTheRoses.Models;
using RunForTheRoses.Repository;

namespace RunForTheRoses
{
    internal class AnswerHelper
    {
        public static RunForTheRosesResult AskForBet(List<RunForTheRosesResult> runForTheRoses)
        {
            while (true)
            {
                var horseInput = Console.ReadLine();
                Console.Write(Environment.NewLine);

                var horseBetAnswer = runForTheRoses.FirstOrDefault(r => string.Equals(r.Horse, horseInput, StringComparison.InvariantCultureIgnoreCase));

                if (horseBetAnswer == null)
                    Console.WriteLine("That horse didn't run in the 2016 Run for the Roses. Please pick a horse from the list.");
                else
                    return horseBetAnswer;
            }
        }

        public static string GetUserBetMessage(string userName, RunForTheRosesResult horseBetAnswer)
        {
            switch (horseBetAnswer.Place)
            {
                case "1":
                    return $"{userName}, {horseBetAnswer.Horse} came in {horseBetAnswer.Place}st place.";
                case "2":
                    return $"{userName}, {horseBetAnswer.Horse} came in {horseBetAnswer.Place}nd place.";
                case "3":
                    return $"{userName}, {horseBetAnswer.Horse} came in {horseBetAnswer.Place}rd place.";
                case "DNF":
                    return $"{userName}, {horseBetAnswer.Horse} did not finish.";
                default:
                    return $"{userName}, {horseBetAnswer.Horse} came in {horseBetAnswer.Place}th place.";
            }
        }

        public static void SaveHorseBet(HorseBet horseBet)
        {
            Console.WriteLine("How do you want to save your result? Press 1 for Plain Text. Press 2 for Json.");
            var type = Console.ReadKey().KeyChar;
            Repository<HorseBet> repository;

            if (type == '1')
                repository = new PlainTextRepository(Program.HorseBetPathBase);
            else //anything other than 1 will return Json in plain text file.
                repository = new JsonRepository(Program.HorseBetPathBase);

            repository.Save(horseBet);
        }
    }
}