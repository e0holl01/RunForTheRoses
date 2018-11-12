using System;
using System.IO;
using RunForTheRoses.Models;
using RunForTheRoses.Repository;


namespace RunForTheRoses
{
    class Program
    {
        public const string HorseBetPathBase = "./HorseBet";

        public static void Main(string[] args)
        {
            //Per requirements, the persisted data must be able to be recalled when the app opens. I am showing that last data here in the beginning & Welcoming the user to the app
            //1
            Console.WriteLine("Welcome to the Repository for the 2016 Kentucky Derby's Run for the Roses.\n");

            //When initially running the app, no user data is available. For the purpose of this app, I created an initial default response
            //When the program is stoped, closed and ran again, it will then return the stored data from the user's answers. 
            
            if (NoFilesToLoad())
                Console.WriteLine("No previous user bets found.");
            else
            {
                var lastBet = HorseBetLoader.GetHorseBetFromFile();
              
                Console.WriteLine($"\nThe last bet was {lastBet.UserName} bet on {lastBet.HorseBetPick}\n");
            }

            Console.Write("Press enter to see the list of 2016 Kentucky Derby horses.");
            Console.ReadKey();

            Console.Clear();    //This method will clear the welcome line. //I didn't want the welcome line to be visible the entire ime the app was open

            //2. The user is then able to see the list of the 2016 Kentucky Derby horses that ran in the race
            var runForTheRoses = RunForTheRosesRepo.LoadRosesResults("./2016RunForTheRosesResults.json"); //returns a list

            //2a. writes the running horse of the derby to the console in shuffled order
            RunForTheRosesRepo.Print(runForTheRoses);

            //3 User enters name to place their bet
            Console.WriteLine("Please enter your name to place a bet.");
            var userName = Console.ReadLine();
            Console.WriteLine();

            //4 User enters their bet
            Console.WriteLine("What horse did you bet to win the 2016 Derby?");

            //4a This code will validate the user's input on the horse they bet on and will display what place they finished and if their horse is not a valid horse it will return null
            //user entry returned from the Console.ReadLine method will be stored in the horseBet variable
            //If user selects a horse that is not on the list or presses enter and no value is captured. User needs to be prompted to pick a horse from the list

            var horseBetAnswer = AnswerHelper.AskForBet(runForTheRoses);
            Console.Clear();
            var userBetMessage = AnswerHelper.GetUserBetMessage(userName, horseBetAnswer);

            Console.WriteLine(userBetMessage);
            Console.WriteLine();

            //5 display users and their last bet

            var horseBet = new HorseBet(userName, horseBetAnswer.Horse);

            AnswerHelper.SaveHorseBet(horseBet);

            Console.WriteLine();
            Console.WriteLine("The program will now close. Thanks!");
            Console.Read();
        }

        private static bool NoFilesToLoad()
        {
            return !File.Exists(HorseBetPathBase + ".txt") && !File.Exists(HorseBetPathBase + ".json");
        }
    }
}