using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace kata.game
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int score()
        {
            int totalScore = 0;
            for (int frame = 0, frameFirstRoll = 0; frame < 10; frame++ )
            {
                totalScore += framScore(frameFirstRoll);
                frameFirstRoll = nextFramFirstRoll(frameFirstRoll);
            }            
            return totalScore;
        }

        private int framScore(int frameFirstRoll)
        {
            if (isStrike(frameFirstRoll))
                return strikeBonus(frameFirstRoll);
            else if (this.isSpare(frameFirstRoll))
                return 10 + spareBonus(frameFirstRoll);
            else
                return sumOfBallsInFrame(frameFirstRoll);
        }

        private int nextFramFirstRoll(int frameFirstRoll)
        {
            return frameFirstRoll + (isStrike(frameFirstRoll) ? 1 : 2);
        }

        private int sumOfBallsInFrame(int frameFirstRoll)
        {
            return rolls[frameFirstRoll] + rolls[frameFirstRoll + 1];
        }

        private int spareBonus(int frameFirstRoll)
        {
            return rolls[frameFirstRoll + 2];
        }

        private int strikeBonus(int frameFirstRoll)
        {
            return 10 + rolls[frameFirstRoll + 1] + rolls[frameFirstRoll + 2];
        }

        private bool isSpare(int frameFirstRoll)
        {
            return (rolls[frameFirstRoll] + rolls[frameFirstRoll + 1] == 10);
        }
        private bool isStrike(int frameFirstRoll)
        {
            return rolls[frameFirstRoll]  == 10;
        }
    }
}
