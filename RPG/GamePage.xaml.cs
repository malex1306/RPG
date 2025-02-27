using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace TextAdventure
{
    public partial class GamePage : ContentPage
    {
        private string _fullText = "Du erwachst in einer Hütte am Rand von Celmora, einer Stadt, die einst voller Leben war, nun aber von Dunkelheit verschlungen wird.\n\nSeit Tagen hörst du Gerüchte über das Herz der Ewigkeit, ein mächtiges Artefakt, das das Schicksal von Celdoria bestimmen könnte!\n\n" +
                                   "Wie heisst du Held?";
        private int _currentIndex = 0;

        public GamePage()
        {
            InitializeComponent();
            AnimateText();
        }

        private async void AnimateText()
        {
            while (_currentIndex < _fullText.Length)
            {
                // Füge das nächste Zeichen hinzu
                StoryLabel.Text += _fullText[_currentIndex];
                _currentIndex++;

                // Warte kurz, bevor das nächste Zeichen angezeigt wird
                await Task.Delay(30); // Verzögerung in Millisekunden (50ms = 0,05 Sekunden)
            }

            // Nach Abschluss der Animation das Entry-Feld und den Button sichtbar machen
            NameEntry.IsVisible = true;
            ConfirmButton.IsVisible = true;
        }

        // Event-Handler für den Bestätigen-Button
        private async void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            string playerName = NameEntry.Text;

            if (!string.IsNullOrWhiteSpace(playerName))
            {
                // Navigiere zur Charaktererstellungsseite und übergebe den Namen
                await Navigation.PushAsync(new CharacterCreationPage(playerName));
            }
            else
            {
                await DisplayAlert("Fehler", "Bitte gib einen gültigen Namen ein.", "OK");
            }
        }
    }
}