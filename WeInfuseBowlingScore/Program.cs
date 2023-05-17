using System;
using System.Collections;
using System.Collections.Generic;

namespace WeInfuseBowlingScore
{
    class Solution
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Please enter your scores for each roll (Ex: 4, 5, X, 8, 1):");
            var userInput = Console.ReadLine();
            string[] bowlingFrames = userInput.Split(", ");

            BowlingScore score = new BowlingScore();

            string[] frameScores = score.CalculateScore(bowlingFrames);
            
            for(int i =  0; i < frameScores.Length; i++)
            {
                Console.WriteLine("Score for frame {0} is: {1}", i + 1, frameScores[i]);
            }
        }
    } 
}
