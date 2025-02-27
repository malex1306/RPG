using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace TextAdventure
{
    public partial class StoryPage : ContentPage
    {
        private Charakter _charakter;
        private int _currentStoryStep = 0;
        private string _playerChoice = ""; 
        private string _fullText = ""; 

        public StoryPage(Charakter charakter)
        {
            InitializeComponent();
            _charakter = charakter;
            DecisionButton1.IsVisible = false;
            DecisionButton2.IsVisible = false;
            UpdateStory();
        }

        private async void UpdateStory()
        {
            DecisionButton1.IsVisible = false;
            DecisionButton2.IsVisible = false;

            switch (_currentStoryStep)
            {
                case 0:
                    _fullText = $"{_charakter.Name}, nachdem du dich umschaust, siehst du eine alte Kiste.\n" +
                                "Sie scheint nicht verriegelt zu sein. Möchtest du sie öffnen?";
                    StoryImage.Source = "chest.jpg";
                    DecisionButton1.Text = "Ja, Kiste öffnen!";
                    DecisionButton2.Text = "Nein, ich sehe mich lieber weiter um.";
                    break;

                case 1:
                    if (_playerChoice == "open_chest") 
                    {
                        _fullText = "Du öffnest vorsichtig die Kiste. In ihrem Inneren liegt ein alter Dolch mit einer seltsamen Gravur.\n\n" +
                                    "Es scheint, als hätte die Waffe eine besondere Geschichte. Möchtest du sie mitnehmen?";
                        StoryImage.Source = "chest_open.png";
                        DecisionButton1.Text = "Ja, den Dolch nehmen!";
                        DecisionButton2.Text = "Nein, ich lasse ihn liegen.";
                    }
                    else  
                    {
                        _fullText = "Du entscheidest dich, die Kiste zu ignorieren und verlässt das Haus richtung Wald.\n\n" +
                                    "Nach einer Weile hörst du ein leises Knurren aus den Büschen.";
                        StoryImage.Source = "dark_forest.png";
                        DecisionButton1.Text = "Nachsehen, woher das Geräusch kommt.";
                        DecisionButton2.Text = "Den Ort schnell verlassen.";
                    }
                    break;

                case 2:
                    if (_playerChoice == "take_dagger")  
                    {
                        _fullText = "Plötzlich raschelt es im Gebüsch! Ein Wolf springt auf dich zu – aber mit dem Dolch kannst du dich verteidigen!\n\n" +
                                    "Nach einem kurzen Kampf treibst du das Tier in die Flucht.";
                        StoryImage.Source = "wolf.png";
                        DecisionButton1.Text = "Weitergehen.";
                        DecisionButton2.IsVisible = false;
                    }
                    else if (_playerChoice == "leave_dagger")  
                    {
                        _fullText = "Plötzlich raschelt es im Gebüsch! Ein Wolf springt auf dich zu – aber du hast keine Waffe!\n\n" +
                                    "Dir bleibt nichts anderes übrig, als die Flucht zu ergreifen!";
                        StoryImage.Source = "wolf.png";
                        DecisionButton1.Text = "Schnell wegrennen!";
                        DecisionButton2.IsVisible = false;
                    }
                    else if (_playerChoice == "investigate_noise")  
                    {
                        _fullText = "Du näherst dich vorsichtig dem Geräusch und entdeckst einen verletzten Hirsch.\n\n" +
                                    "Er scheint harmlos zu sein, aber vielleicht führt seine Spur dich zu etwas Wertvollem.";
                        StoryImage.Source = "deer.png";
                        DecisionButton1.Text = "Dem Hirsch folgen.";
                        DecisionButton2.Text = "Ihn zurücklassen und weitergehen.";
                    }
                    else if (_playerChoice == "leave_area")  
                    {
                        _fullText = "Du verlässt den Ort in Eile und kommst an einen kleinen Fluss.\n\n" +
                                    "Vielleicht kannst du hier eine Pause machen und etwas trinken.";
                        StoryImage.Source = "river.png";
                        DecisionButton1.Text = "Am Fluss rasten.";
                        DecisionButton2.Text = "Dem Flusslauf folgen.";
                    }
                    break;
            }

            await DisplayTextWithAnimation(_fullText);
            DecisionButton1.IsVisible = true;
            DecisionButton2.IsVisible = DecisionButton2.Text != "";
        }

        private async Task DisplayTextWithAnimation(string text)
        {
            StoryTextLabel.Text = "";
            foreach (char c in text)
            {
                StoryTextLabel.Text += c;
                await Task.Delay(30); 
            }
        }

        private void OnDecisionButton1Clicked(object sender, EventArgs e)
        {
            if (_currentStoryStep == 0)
            {
                _playerChoice = "open_chest";  
            }
            else if (_currentStoryStep == 1)
            {
                if (_playerChoice == "open_chest")
                {
                    _playerChoice = "take_dagger";  
                }
                else if (_playerChoice == "investigate_noise")
                {
                    _playerChoice = "investigate_noise";  
                }
                else if (_playerChoice == "leave_area")
                {
                    _playerChoice = "leave_area";  
                }
            }

            _currentStoryStep++;
            UpdateStory();
        }

        private void OnDecisionButton2Clicked(object sender, EventArgs e)
        {
            if (_currentStoryStep == 0)
            {
                _playerChoice = "leave_chest";  
            }
            else if (_currentStoryStep == 1)
            {
                if (_playerChoice == "open_chest")
                {
                    _playerChoice = "leave_dagger";  
                }
                else if (_playerChoice == "investigate_noise")
                {
                    _playerChoice = "leave_area";  
                }
            }

            _currentStoryStep++;
            UpdateStory();
        }
    }
}
