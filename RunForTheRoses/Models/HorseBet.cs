namespace RunForTheRoses.Models
{
    public class HorseBet
    {
        public HorseBet(string userName, string horseBetPick)
        {
            UserName = userName;
            HorseBetPick = horseBetPick;
        }

        public string UserName { get; set; }
        public string HorseBetPick { get; set; }
        public override string ToString()
        {
            return $"{UserName},{HorseBetPick}";
        }
    }
}
