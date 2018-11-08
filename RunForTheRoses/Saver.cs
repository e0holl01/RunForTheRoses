namespace RunForTheRoses
{

    //This is the saver class. The user is asked how they want to save their data. This is the base class for Plain Text and for Json.
    abstract class Saver<T> 
    {
        public abstract void Save(T obj);
        public string Path { get; set; }
        public Saver(string path)
        {
            Path = path;
        }


        public abstract T Load(string text);

    }
}
