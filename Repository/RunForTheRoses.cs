using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RunForTheRoses.Repository
{
     public static class RunForTheRosesRepo
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


    }

}
