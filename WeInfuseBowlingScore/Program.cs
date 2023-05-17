using System;
using System.Collections;
using System.Collections.Generic;

namespace WeInfuseBowlingScore
{
    class Solution
    {
        public static void Main(String[] args)
        {
            string[] bowlingFrames = { "4", "5", "X", "8", "1", "3", "/", "5", "2", "4", "/", "X", "4", "/", "8", "1", "X", "X", "5" }; // extra frame on 10
            //string[] bowlingFrames = { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" };
            //string[] bowlingFrames = { "4", "5", "X", "8", "/"};
            //string[] bowlingFrames = { "4", "5", "X", "8" };
            //string[] bowlingFrames = { "4", "5", "X", "8", "1" };


            //Console.WriteLine("Please enter your scores for each roll");
            //var userInput = Console.ReadLine();
            //string[] bowlingFrames = userInput.Split(" ");


            BowlingScore score = new BowlingScore();

            string[] frameScores = score.CalculateScore(bowlingFrames);
            
            for(int i =  0; i < frameScores.Length; i++)
            {
                Console.WriteLine("Score for frame {0} is: {1}", i + 1, frameScores[i]);
            }
        }
    } 
}
