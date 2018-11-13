using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace RunForTheRoses.Repository
{
    public static class RunForTheRosesRepo

        //Deserializes list of horses
    {
        public static List<RunForTheRosesResults> DeserializeRunForTheRosesResults(string fileName)//returns list of horses
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

        

        //Shuffles list of horsese
        public static List<RunForTheRosesResults> Shuffle(List<RunForTheRosesResults> runForTheRoses)
        {
            var random = new Random();
            return runForTheRoses.OrderBy(r => random.Next()).ToList();
        }

        //Prints the shuffled list of horses to the console
        public static void Print(List<RunForTheRosesResults> runForTheRoses)
        {
            foreach (var runForTheRosesResult in runForTheRoses)
                Console.WriteLine(runForTheRosesResult.Horse);

            Console.Write(Environment.NewLine); //provides space after list of horses
        }
    }
}




