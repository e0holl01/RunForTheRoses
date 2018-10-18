using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace RunForTheRoses
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Welcome the user to the app
            Console.Write("Welcome to the Repository for the 2016 Kentucky Derby's Run for the Roses. Press enter to see the list of placing horses."); 
            Console.ReadKey(true);
            ClearLine(); 

            //The user is then able to see the list of the 2016 Kentucky Derby horses that ran in 
            //the race
            
            string derbyDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo derbydirectory = new DirectoryInfo(derbyDirectory);
            var fileName = Path.Combine(derbydirectory.FullName, "2016RunForTheRosesResults.json");
            var runForTheRoses = DeserializeRunForTheRosesResults(fileName);
            //writes the running horse of the derby to the console from 2016RunForTheRoses.cvs file.
            foreach (var derbyHorse in runForTheRoses)
            {
                Console.WriteLine(derbyHorse.Horse);
                
            }
            Console.Write(Environment.NewLine); //provides space after list of horses
            //The user is then prompted to enter what horse they bet on
            Console.WriteLine("What horse did you bet on in the 2016 Kentucky Derby?");

            //This code will validate the user's input on the horse they bet on and will display what place they 
            //finished and if their horse is not a valid horse it will return null
            
          
            string horseBet = Console.ReadLine(); //user entry
            var horse = runForTheRoses.FirstOrDefault(r => string.Equals(r.Horse, horseBet, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine(horse == null ? "That horse didn't run in the 2016 Run for the Roses.": horse.Horse + " came in "+ horse.Place + " place."); //way to look at 2016RunForTheRoses to validate?
            Console.ReadLine();

            fileName = Path.Combine(derbydirectory.FullName, "DerbyBet.json");
            SerializeRunForTheRosesResultsToFile(runForTheRoses, fileName);
        }

        //private static object DeserializeRunForTheRoses(string fileName)
        //{
        //    throw new NotImplementedException();
        //}

        //This method will clear the welcome line. 
        //I didn't want the welcome line to be visible the entire ime the app was open
        public static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        //The ReadFile method reads the entire file to the end of it's file
        public static string ReadFile(string fileName) 
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }


        //Makes List of RunFortheRosesResults
        public static List<RunForTheRosesResults> ReadRunForTheRosesResults(string fileName)
        {
            var runForTheRosesResults = new List<RunForTheRosesResults>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine(); //reads next line in file and returns. Reads to end of file and returns null
                while ((line = reader.ReadLine()) != null) //reads file to end of line if not null
                {
                    string[] values = line.Split(',');
                    new RunForTheRosesResults().Race = values[1];
                    new RunForTheRosesResults().Place = values[2];
                    new RunForTheRosesResults().Horse = values[3];
                    new RunForTheRosesResults().Add(new RunForTheRosesResults()); //adds values to list
                }
            }
            return runForTheRosesResults; //returns a list of the RunForTheRosesResults

        }

         public static List<RunForTheRosesResults> DeserializeRunForTheRosesResults(string fileName)//I want this to return list of horses
        {
            var derbyResults = new List<RunForTheRosesResults>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                derbyResults = serializer.Deserialize<List<RunForTheRosesResults>>(jsonReader);
            }
            return derbyResults; //returns list of the horse races
        }

        public static void SerializeRunForTheRosesResultsToFile(List<RunForTheRosesResults> derbyResults, string fileName2) //took list and wrote to json file
        {

            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName2))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, derbyResults);
            }


        }
    }



} 
