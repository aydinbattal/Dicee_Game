using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
            List<int> numbers = _game.Roll();
            Random random = new Random();
            Dice1.Text = numbers[0].ToString();
            Dice2.Text = numbers[1].ToString();
            //this works too but numbers list not needed
            //Dice1.Text = random.Next(1, 7).ToString();
            //Dice2.Text = random.Next(1, 7).ToString();

            TurnScore.Text = $"Joe: {_game.turnScore}";

            if (_game.IsPlayer1 == true)
            {
                _game.player1Points = (_game.player1Points + _game.turnScore);
                RollButton.Content = $"Roll (Player 1)"; 
                Player1Score.Text = $"Player 1 Score: {_game.player1Points}";
                _game.IsPlayer1 = false;
            }
            else
            {
                _game.player2Points = (_game.player2Points + _game.turnScore);
                RollButton.Content = $"Roll (Player 2)";
                Player2Score.Text = $"Player 2 Score: {_game.player2Points}";
                _game.IsPlayer1 = true;
            }
        }
    }
}
