using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DiceeApp_AydinBattal
{
    class Game
    {
        public int Player1TurnScore;
        public int Player2TurnScore;
        public int Player1Points;
        public int Player2Points;
        public bool IsPlayer1;
        public int Rounds;

        public Game()
        {
            Rounds = 1;
        }

        public bool IsGameOver()
        {
            return Rounds == 10 || Player1TurnScore == 300 || Player2TurnScore == 300;
            

        }


        public List<int> Roll()
        {
            Rounds = Rounds + 1;


            Random randomNumberGenerator = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < 2; i++)
            {
                numbers.Add(randomNumberGenerator.Next(1, 7));


            }

            
                    


            CalculateTurn(numbers);
            return numbers;
            
        }

        private void CalculateTurn(List<int> numbers)
        {
            if /*(Rounds % 2 == 0)*/ (IsPlayer1 == false)
            {
                if (numbers[0] == numbers[1])
                {
                    if (numbers[0] == 6 && numbers[1] == 6)
                    {
                        Player1TurnScore = Player1TurnScore + 100;

                    }
                    else
                    {
                        Player1TurnScore = numbers[0] * 10;
                    }
                }
                else
                {
                    Player1TurnScore = 0;
                }

            }
            else
            {
                if (numbers[0] == numbers[1])
                {
                    if (numbers[0] == 6 && numbers[1] == 6)
                    {
                        Player2TurnScore = Player2TurnScore + 100;

                    }
                    else
                    {
                        Player2TurnScore = numbers[0] * 10;
                    }
                }
                else
                {
                    Player2TurnScore = 0;
                }
            }
            


        }

        public void EndGame()
        {
            if (Player1Points > Player2Points)
            {
                MessageDialog message = new MessageDialog($"The game is over!\nPlayer 1 won with a score of {Player1Points}");
                message.ShowAsync();
            }
                
            else if (Player2Points > Player1Points)
            {
                MessageDialog message = new MessageDialog($"The game is over!\nPlayer 2 won with a score of {Player2Points}");
                message.ShowAsync();
            }
                
            else
            {
                MessageDialog message = new MessageDialog($"The game is over!\nIt's a draw!");
                message.ShowAsync();
            }
                
        }


        //public List<int> Jackpot()
        //{
        //    List<int> jackpots = new List<int>();
        //    jackpots.Add(1);
        //    CalculateJackpot(jackpots);
        //    return jackpots;
        //}

        //private void CalculateJackpot(List<int> jackpots)
        //{
        //    for (int i = 0; i >= jackpots.Count; i++)
        //    {
        //        TurnScore = TurnScore + 100;
        //    }

        //}

    }
}
