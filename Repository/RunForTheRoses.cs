using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RunForTheRoses.Models;

namespace RunForTheRoses.Repository
{
    public static class RunForTheRosesRepo
    {
        public static List<RunForTheRosesResult> LoadRosesResults(string fileName) //returns list of horses
        {
            List<RunForTheRosesResult> derbyResults;
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
                derbyResults = serializer.Deserialize<List<RunForTheRosesResult>>(jsonReader);

            return derbyResults; //returns list of the horse races
        }

        public static void Print(List<RunForTheRosesResult> runForTheRoses)
        {
            var random = new Random();
            //for (int i = 19; i >= 0; i--) this works but i want to use the list and the count method so i'm not relying on just a number in the list.
            //for (int i = 0; i < runForTheRoses.Count; i++) //producing duplicates now...gotthis method from the mentor, it initially worked so not sure why it quit working
            for (var i = runForTheRoses.Count - 1; i >= 1; i--)
            {
                var rdm = random.Next(0, i + 1);
                Console.WriteLine(runForTheRoses[rdm].Horse);
                var holder = runForTheRoses[rdm];
                runForTheRoses[rdm] = runForTheRoses[i];
                runForTheRoses[i] = holder;
            }
            Console.Write(Environment.NewLine); //provides space after list of horses
        }
    }
}
