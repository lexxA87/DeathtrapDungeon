namespace Assets.Scripts
{
    public class Player
    {
        public int Master { get; set; }

        public int Stamina { get; set; }

        public int Luck { get; set; }

        public int Food { get; set; } = 10;

        public int Gold { get; set; } = 0;

        public Player(int master, int stamina, int luck)
        {
            Master = master;
            Stamina = stamina;
            Luck = luck;
        }
    }
}
