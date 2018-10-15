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
            //Welcome the user to the app//
            Console.WriteLine("Welcome to the 2016 Repository for Leading up to the Run for the Roses. Press enter to see the list of placing horses."); 
            Console.ReadKey(true);
            ClearLine(); //will clear the welcome line. I didn't want the welcome line to be visible the entire time the app was open
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "HorseRaceResults.csv");
            var fileContents = ReadFile(fileName);
            fileName = Path.Combine(directory.FullName, "HorseRaces.json");
            var horseRaces = DeserializeHorseRaces(fileName);


            foreach (var horseRace in horseRaces) //writes the winning horse of each race to the console from HorseRace.cs file.
            {
                Console.WriteLine(horseRace.Win + " was the winning horse at " + horseRace.Race + ".");
                Console.WriteLine(horseRace.Place + " placed 2nd at " + horseRace.Race + ".");
                Console.WriteLine(horseRace.Show + " placed 3rd at " + horseRace.Race + ".");
                Console.WriteLine(horseRace.Fourth + " came in 4th at " + horseRace.Race + ".");
            }

            fileName = Path.Combine(directory.FullName, "DerbyHorses.json"); //wrote horses back to json file
            SerializeHorseRaceToFile(horseRaces, fileName);

            Console.Write(Environment.NewLine); //provides space after list of horses
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Here are the results of the 2016 Kentucky Derby. Press enter to see the list.");
            Console.ReadKey(true);

            Console.WriteLine("What horse did you bet on in the 2016 Kentucky Derby?");

            string derbyDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo derbydirectory = new DirectoryInfo(currentDirectory);
            //var fileName2 = Path.Combine(directory.FullName, "2016RunForTheRosesResults.csv");
            //var fileContents2 = ReadFile(fileName2);
           var fileName2 = Path.Combine(directory.FullName, "2016RunForTheRosesResults.json");
            var runForTheRoses = DeserializeRunForTheRosesResults(fileName2);
            string horseBet = Console.ReadLine(); //user entry
            var horse = runForTheRoses.FirstOrDefault(r => string.Equals(r.Horse, horseBet, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine(horse == null ? "Couldn't find horse.": "Finished "+ horse.Place); //way to look at 2016RunForTheRoses to validate?
            Console.ReadLine();
        }

        private static object DeserializeRunForTheRoses(string fileName)
        {
            throw new NotImplementedException();
        }

        public static void ClearLine() //clears the Welcome line in the app //need a way to add a pause so it doesn't clear right away
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        public static string ReadFile(string fileName) //reads file to end of file
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<RaceResults> ReadRaceResults(string fileName)
        {
            var raceResults = new List<RaceResults>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine(); //reads next line in file and returns. Reads to end of file and returns null
                while ((line = reader.ReadLine()) != null) //reads file to end of line if not null
                {
                    var raceResult = new RaceResults();
                    string[] values = line.Split(',');

                    DateTime Date;
                    if (DateTime.TryParse(values[0], out Date))
                    {
                        raceResult.Date = Date;
                    }
                    raceResult.Track = values[1];
                    raceResult.Race = values[2];
                    raceResult.Win = values[3];
                    raceResult.Place = values[4];
                    raceResult.Show = values[5];
                    raceResult.Fourth = values[6];
                    raceResults.Add(raceResult); //adds values to list
                }
            }
            return raceResults; //returns a list

        }

        public static List<HorseRace> DeserializeHorseRaces(string fileName)//I want this to return list of horses
        {
            var horseRaces = new List<HorseRace>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                horseRaces = serializer.Deserialize<List<HorseRace>>(jsonReader);
            }

            return horseRaces; //returns list of the horse races
        }

        public static void SerializeHorseRaceToFile(List<HorseRace> horseRaces, string fileName) //took list and wrote to json file
        {

            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, horseRaces);
            }


        }

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
            return runForTheRosesResults; //returns a list

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
