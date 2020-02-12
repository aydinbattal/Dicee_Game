using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiceeApp_AydinBattal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Game _game = new Game();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (_game.IsGameOver())
            {
                _game.EndGame();
                _game.Player1TurnScore = 0;
                _game.Player2TurnScore = 0;
                _game.Player1Points = 0;
                _game.Player2Points = 0;
                Dice1.Text = $"1";
                Dice2.Text = $"1";
                TurnScore.Text = $"Turn Score: 0";
                Player1Score.Text = $"Player 1 Score: 0";
                Player2Score.Text = $"Player 2 Score: 0";
                RollButton.Content = $"Roll (Player1)";
                _game = new Game();
                return;
            }

            List<int> numbers = _game.Roll();
            Random random = new Random();
            Dice1.Text = numbers[0].ToString();
            Dice2.Text = numbers[1].ToString();
            //this works too but numbers list not needed
            //Dice1.Text = random.Next(1, 7).ToString();
            //Dice2.Text = random.Next(1, 7).ToString();

            if /*(_game.Rounds % 2 == 0)*/  (_game.IsPlayer1 == false) 
            {
                TurnScore.Text = $"Turn Score: {_game.Player1TurnScore}";

                _game.Player1Points = (_game.Player1Points + _game.Player1TurnScore);
                if (_game.Player1TurnScore == 200)
                    TurnScore.Text = $"Double Jackpot! Turn Score: {_game.Player1TurnScore}";

                
                Player1Score.Text = $"Player 1 Score: {_game.Player1Points}";
                RollButton.Content = $"Roll (Player 2)";
                _game.IsPlayer1 = true;
            }
            else
            {
                TurnScore.Text = $"Turn Score: {_game.Player2TurnScore}";

                _game.Player2Points = (_game.Player2Points + _game.Player2TurnScore);
                if (_game.Player2TurnScore == 200)
                    TurnScore.Text = $"Double Jackpot! Turn Score: {_game.Player2TurnScore}";
                //else
                //    TurnScore.Text = $"Turn Score: {_game.Player2TurnScore}";

                Player2Score.Text = $"Player 2 Score: {_game.Player2Points}";

                RollButton.Content = $"Roll (Player 1)";
                _game.IsPlayer1 = false;
            }


            
        }
    }
}
