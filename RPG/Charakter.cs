namespace TextAdventure
{
    public class Charakter
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public int Luck { get; set; }

        // Erstelle einen Charakter ohne feste Punkte
        public Charakter(string playerName)
        {
            Name = playerName;
            Strength = 0;
            Health = 0;
            Luck = 0;
        }

        // Methode, um Punkte zu verteilen
        public void DistributePoints(int strengthPoints, int healthPoints, int luckPoints)
        {
            Strength = strengthPoints;
            Health = healthPoints;
            Luck = luckPoints;
        }
    }
}