namespace TextAdventure
{
    public class CharacterAttributes
    {
        public int StrengthPoints { get; private set; }
        public int HealthPoints { get; private set; }
        public int LuckPoints { get; private set; }

        private const int MaxPoints = 10;  // Maximal verfügbare Punkte für jedes Attribut
        private int _remainingPoints = MaxPoints;

        // Methode zum Hinzufügen von Punkten zu Stärke
        public bool AddStrengthPoint()
        {
            if (_remainingPoints > 0)
            {
                StrengthPoints++;
                _remainingPoints--;
                return true;
            }
            return false;
        }

        // Methode zum Hinzufügen von Punkten zu Gesundheit
        public bool AddHealthPoint()
        {
            if (_remainingPoints > 0)
            {
                HealthPoints++;
                _remainingPoints--;
                return true;
            }
            return false;
        }

        // Methode zum Hinzufügen von Punkten zu Glück
        public bool AddLuckPoint()
        {
            if (_remainingPoints > 0)
            {
                LuckPoints++;
                _remainingPoints--;
                return true;
            }
            return false;
        }
    }
}