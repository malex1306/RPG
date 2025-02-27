using Microsoft.Maui.Controls;

namespace TextAdventure
{
    public partial class AttributeDistributionPage : ContentPage
    {
        private Charakter _charakter;
        private int _strengthPoints = 0;
        private int _healthPoints = 0;
        private int _luckPoints = 0;

        public AttributeDistributionPage(Charakter charakter)
        {
            InitializeComponent();
            _charakter = charakter;

            // Zeige die Klasse und den Namen des Charakters an
            CharacterInfoLabel.Text = $"{_charakter.Name}, {_charakter.Class}";

            // Setze die initialen Punktzahlen auf 0
            UpdatePointDisplays();
        }

        // Methode, um die Punkteverteilung anzuzeigen
        private void UpdatePointDisplays()
        {
            StrengthPointsLabel.Text = $"Stärke: {_strengthPoints}";
            HealthPointsLabel.Text = $"Gesundheit: {_healthPoints}";
            LuckPointsLabel.Text = $"Glück: {_luckPoints}";
        }

        // Methode, um Stärke-Punkte zu erhöhen
        private void OnStrengthButtonClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int points = int.Parse(clickedButton.Text);
            _strengthPoints += points;
            UpdatePointDisplays();
        }

        // Methode, um Gesundheit-Punkte zu erhöhen
        private void OnHealthButtonClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int points = int.Parse(clickedButton.Text);
            _healthPoints += points;
            UpdatePointDisplays();
        }

        // Methode, um Glück-Punkte zu erhöhen
        private void OnLuckButtonClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int points = int.Parse(clickedButton.Text);
            _luckPoints += points;
            UpdatePointDisplays();
        }

        // Bestätigungsbutton, um die Punkte auf den Charakter zu verteilen
        private async void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            // Verteile die Punkte auf den Charakter
            _charakter.DistributePoints(_strengthPoints, _healthPoints, _luckPoints);

            // Weiter zur nächsten Seite (z. B. MainGamePage)
            await Navigation.PushAsync(new MainGamePage(_charakter));
        }

        private void StrengthButton1_OnClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
