using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForTheRoses
{
    abstract class Saver<T>
    {
        public abstract void Save(T obj);
        public string Path { get; set; }
        public Saver(string path)
        {
            Path = path;
        }
    }
}
