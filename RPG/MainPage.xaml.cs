using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace TextAdventure
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Event-Handler für den Button-Klick
            NewGame.Clicked += OnNewGameClicked;

            // Starte die Animation mit einer kurzen Verzögerung
            Task.Delay(100).ContinueWith(_ => AnimateMenu(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void AnimateMenu()
        {
            // Setze das Menü außerhalb des Bildschirms
            MenuLayout.TranslationY = -MenuLayout.Height;

            // Animation, um das Menü von oben hereinscrollen zu lassen
            MenuLayout.TranslateTo(0, 0, 2000, Easing.SinInOut);
        }

        // Asynchrone Methode für den Button-Klick
        private async void OnNewGameClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());
        }
    }
}