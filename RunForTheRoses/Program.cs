﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RunForTheRoses
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the 2016 Repository for Leading up to the Run for the Roses. Press enter to see the list of placing horses."); //need to add pause so viewer can see the welcome line and then the line will clear.
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

            Console.WriteLine("What horse did you bet on in the 2016 Kentucky Derby?");
            string line = Console.ReadLine(); //disappears after answer is written
            Console.WriteLine("Did your horse place?");
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
    }



} 
