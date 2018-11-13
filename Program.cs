using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using RunForTheRoses.Models;
using RunForTheRoses.Repository;


namespace RunForTheRoses
{
    class Program
    {

        public static void Main()
        {
            //1. Welcoming the user to the app

            Console.WriteLine("Welcome to the Repository for the 2016 Kentucky Derby's Run for the Roses.\n"); //\n = new line

            //2. 
            //When initially running the app, no user data is available. For the purpose of this app, I created an initial default response
            //When the program is stoped, closed and ran again, it will then return the stored data from the user's answers and load selection. 
            HorseBet lastBet = null;
            string path = "./HorseBet";
            if (!File.Exists(path + ".txt") && !File.Exists(path + ".json"))
            {

                Console.WriteLine("No previous user bets found. \n");
            }
            else
            {

                while (lastBet == null)
                {
                    Console.WriteLine("How do you want to load the last Horse Bet?  Press 1 for Plain Text. Press 2 for Json.");
                    var type = Console.ReadKey().KeyChar;
                    Saver<HorseBet> saver;

                    if (type == '1') //if the txt file does not exits
                    {
                        if (!File.Exists(path + ".txt"))
                        {
                            Console.WriteLine("\nFile does not exits. Pick another option.");

                        }
                        else //if the txt file does exist
                        {
                            saver = new PlainTextSaver(path + ".txt");

                            lastBet = saver.Load();
                        }


                    }
                    else //will read the json file
                    {
                        if (!File.Exists(path + ".json"))
                        {
                            Console.WriteLine("\nFile does not exits. Pick another option.");

                        }
                        else
                        {
                            saver = new JsonSaver(path + ".json");

                            lastBet = saver.Load();
                        }

                    }

                }



                Console.WriteLine($"\nThe last bet was {lastBet.UserName} bet on {lastBet.HorseBetPick}.\n");

            }


            Console.Write("Press enter to see the list of 2016 Kentucky Derby horses.\n");
            Console.ReadKey();
            Console.Clear();    //This method will clear the welcome line. //I didn't want the welcome line to be visible the entire ime the app was open

            //2. The user is then able to see the list of the 2016 Kentucky Derby horses that ran in the race

            var runForTheRoses = RunForTheRosesRepo.DeserializeRunForTheRosesResults("./2016RunForTheRosesResults.json"); //returns a list

            //2a. writes the running horse of the derby to the console in shuffled order

            var shuffled = RunForTheRosesRepo.Shuffle(runForTheRoses);
            RunForTheRosesRepo.Print(shuffled);

            Console.Write(Environment.NewLine); //provides space after list of horses

            //3 User enters name to place their bet
            Console.WriteLine("Please enter your name to place a bet.");
            var userName = Console.ReadLine();
            Console.Write(Environment.NewLine);

            //4 User enter's their bet
            Console.Write("What horse did you bet to win the 2016 Derby?");
            Console.Write(Environment.NewLine);

            //4a This code will validate the user's input on the horse they bet on and will display what place they finished and if their horse is not a valid horse it will return null
            //user entry returned from the Console.ReadLine method will be stored in the horseBet variable
            //If user selects a horse that is not on the list or presses enter and no value is captured. User needs to be prompted to pick a horse from the list

            bool nullAnswer = true;
            while (nullAnswer)
            {
                string horseInput = Console.ReadLine();
                Console.Write(Environment.NewLine);

                var horseBetAnswer = runForTheRoses.FirstOrDefault(r => string.Equals(r.Horse, horseInput, StringComparison.InvariantCultureIgnoreCase));

                if (horseBetAnswer == null)
                {
                    Console.WriteLine("That horse didn't run in the 2016 Run for the Roses. Please pick a horse from the list.");
                }
                else
                {
                    var UserBetString = "";
                    string switchCase = horseBetAnswer.Place.ToString();
                    Console.Clear();
                    switch (switchCase)
                    {
                        case "1":
                            UserBetString = userName + ", " + horseBetAnswer.Horse + " came in " + horseBetAnswer.Place + "st place.";
                            break;

                        case "2":
                            UserBetString = userName + ", " + horseBetAnswer.Horse + " came in " + horseBetAnswer.Place + "nd place.";
                            break;

                        case "3":
                            UserBetString = userName + ", " + horseBetAnswer.Horse + " came in " + horseBetAnswer.Place + "rd place.";
                            break;

                        case "DNF":
                            UserBetString = userName + ", " + horseBetAnswer.Horse + " did not finish.";
                            break;

                        default:
                            UserBetString = userName + ", " + horseBetAnswer.Horse + " came in " + horseBetAnswer.Place + "th place.";
                            break;
                    }

                    Console.WriteLine(UserBetString);
                    nullAnswer = false;//breaks out of loop as long as user picks valid horse from list

                    //5 display users and their last bet

                    var horseBet = new HorseBet
                    {
                        UserName = userName,
                        HorseBetPick = horseBetAnswer.Horse
                    };

                    Console.WriteLine("\nHow do you want to save your result? Press 1 for Plain Text. Press 2 for Json.");
                    var type = Console.ReadKey().KeyChar;
                    Saver<HorseBet> saver;


                    if (type == '1')
                    {
                        saver = new PlainTextSaver(path + ".txt");


                    }
                    else //anything other than 1 will return Json file
                    {
                        saver = new JsonSaver(path + ".json");


                    }

                    saver.Save(horseBet);

                }

            }

            //6
            Console.WriteLine("\n\nGot it! The program will now close.");

            Console.Read();

        }

    }
}