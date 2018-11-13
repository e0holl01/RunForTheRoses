namespace RunForTheRoses.Models
{
    class HorseBet
    {
        public string UserName { get; set; }
        public string HorseBetPick { get; set; }
        public override string ToString()
        {
          
           return $"{UserName},{HorseBetPick}";

        }
    }
}
