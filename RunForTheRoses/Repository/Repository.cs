using System.IO;

namespace RunForTheRoses.Repository
{

    //This is the saver class. The user is asked how they want to save their data. This is the base class for Plain Text and for Json.
    abstract class Repository<T> 
    {
        public abstract void Save(T obj);
        public string Path { get; set; }

        protected Repository(string path)
        {
            Path = path;
        }


        public abstract T Load();

        public bool FileExists()
        {
            return File.Exists(Path);
        }
    }
}
