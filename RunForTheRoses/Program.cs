using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RunForTheRoses
{
    class Program
    {
      public static void Main()
        {
         Console.WriteLine("Welcome to the 2016 Repository for Leading up to the Run for the Roses."); //need to add pause so viewer can see the welcome line and then the line will clear.
            ClearLine(); //will clear the welome line. I didn't want the welcome line to be visible the entire time the app was open
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "CSVDerby prep 2016.csv");
            var fileContents = ReadRaceResults(fileName);
            Console.ReadLine();
   
        }

        public static void ClearLine() //clears the Welcome line in the app //need a way to add a pause so it doesn't clear right away
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        public static string ReadFile(string fileName)
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
                reader.ReadLine();
                while((line = reader.ReadLine()) !=null)
                {
                    var raceResult = new RaceResults();
                    string[] values = line.Split(',');
                    
                    DateTime Date;
                    if (DateTime.TryParse(values[0], out Date))
                    {
                        raceResult.Date = Date;
                    }
                    raceResult.Race = values[1];
                    raceResult.Win = values[2];
                    raceResult.Place = values[3];
                    raceResult.Show = values[4];
                    raceResult.Fourth = values[5];
                    raceResults.Add(raceResult);
                }
            }
            return raceResults;
        }
    }
}
