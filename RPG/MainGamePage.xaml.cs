using Microsoft.Maui.Controls;

namespace TextAdventure
{
    public partial class MainGamePage : ContentPage
    {
        private Charakter _charakter;

        public MainGamePage(Charakter charakter)
        {
            InitializeComponent();
            _charakter = charakter;

            // Zeige Charakter-Informationen auf der Spiel-Seite an
            CharacterInfoLabel.Text = $"{_charakter.Name}, {_charakter.Class}, Stärke: {_charakter.Strength}, Gesundheit: {_charakter.Health}, Glück: {_charakter.Luck}";
        }
    }
}