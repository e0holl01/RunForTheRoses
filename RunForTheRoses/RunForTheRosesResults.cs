using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rootobject
{
    public RunForTheRosesResults[] RunForTheRosesResults { get; set; }
}

public class RunForTheRosesResults
{
    public string Race { get; set; }
    public object Place { get; set; }
    public string Horse { get; set; }

    internal void Add(RunForTheRosesResults runForTheRosesResults)
    {
        throw new NotImplementedException();
    }
}
