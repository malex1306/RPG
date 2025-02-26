using Microsoft.Maui.Controls;

namespace TextAdventure
{
    public partial class CharacterCreationPage : ContentPage
    {
        private string _playerName;
        private string _selectedClass;
        private int _selectedClassIndex;

        public CharacterCreationPage(string playerName)
        {
            InitializeComponent();
            _playerName = playerName;

            // Begrüßung mit dem eingegebenen Namen anzeigen
            WelcomeLabel.Text = $"Willkommen, {_playerName}!";
        }

        private async void OnClassButtonClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Bestimme die ausgewählte Klasse basierend auf dem Button-Text
            if (clickedButton == FighterButton)
            {
                _selectedClass = "Kämpfer - Schwert und Schild";
                _selectedClassIndex = 1;
            }
            else if (clickedButton == MageButton)
            {
                _selectedClass = "Magier - Zauberstab und Elementarmagie";
                _selectedClassIndex = 2;
            }
            else if (clickedButton == ArcherButton)
            {
                _selectedClass = "Bogenschütze - Pfeil, Bogen und Armbrust";
                _selectedClassIndex = 3;
            }

            // Zeige die Klasse und Infos dazu an
            await DisplayAlert("Klasse gewählt", $"Du hast die Klasse {_selectedClass} gewählt.", "OK");

            // Mache den Bestätigungsbutton sichtbar
            ConfirmButton.IsVisible = true;
        }

        private async void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            // Erstelle den Charakter
            Charakter charakter = new Charakter(_playerName)
            {
                Class = _selectedClass
            };

            // Navigiere zur Attribute Distribution Page, um Punkte zu verteilen
            await Navigation.PushAsync(new AttributeDistributionPage(charakter));
        }
    }
}
