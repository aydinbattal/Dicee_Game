using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceeApp_AydinBattal
{
    class Game
    {
        public int turnScore;
        public int player1Points;
        public int player2Points;
        public bool IsPlayer1;
        public List<int> Roll()
        {
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
            if (numbers[0] == numbers[1])
            {
                if (numbers[0] == 6 && numbers[1] == 6)
                {
                    turnScore = 100;
                }
                else
                {
                    turnScore = numbers[0] * 10;
                }
            }
            else
            {
                turnScore = 0;
            }
            
            
        }

        public void PlayerTurn()
        {
            IsPlayer1 = true;
            Roll();
            IsPlayer1 = false;
            Roll();
        }
    }
}
