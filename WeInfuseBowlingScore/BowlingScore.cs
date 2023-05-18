using System;
using System.Collections;
using System.Collections.Generic;

namespace WeInfuseBowlingScore
{
    public class BowlingScore
    {
        public string[] CalculateScore(string[] rolls)
        {
            int frameScore = 0;
            int prevFrameScore = 0;
            int prevFrameTwoScore = 0;
            int extraFrameScore = 0;
            int rollOne = 0;
            int rollTwo = 0;
            int frameCount = 1; 
            bool isStrike = false;
            bool isStrikeTwo = false; 
            bool isSpare = false;
            List<string> frameScoreList = new List<string>();

            for (int i = 0; (i + 1 < rolls.Length && frameCount <= 10); i++)
            {
                if (rolls[i] != "X")
                {
                    rollOne = int.Parse(rolls[i]);
                }
                else
                {
                    rollOne = 10;
                }

                if (isSpare == true)// if previous frame was a spare add in the bonus points now
                {
                    isSpare = false;
                    prevFrameScore = 10 + rollOne;
                    frameScoreList.Add(prevFrameScore.ToString());
                }

                if (isStrikeTwo == true && rollOne == 10)//if 3 strikes in a row, add score 2 previous frames
                {
                    prevFrameTwoScore = 30;
                    frameScoreList.Add(prevFrameTwoScore.ToString());
                }

                if (isStrikeTwo == true && rollOne != 10)//if 2 strikes in a row, add score 2 previous frames
                {
                    isStrikeTwo = false;
                    prevFrameTwoScore = 20 + rollOne;
                    frameScoreList.Add(prevFrameTwoScore.ToString());
                }

                if (isStrike == true && rollOne == 10)
                {
                    isStrikeTwo = true;
                }

                if (rollOne < 10)
                {
                    if (i + 1 < rolls.Length)
                    {
                        if (rolls[i + 1] != "/")
                        {
                            rollTwo = int.Parse(rolls[i + 1]);
                        }
                        else
                        {//if "/" entered we get value of that roll
                            rollTwo = 10 - rollOne;
                            isSpare = true;
                            i++; // advance to next frame
                        }
                    }
                    else
                    {
                        break;
                    }

                    if (isStrikeTwo == true && frameCount == 10)
                    {
                        prevFrameTwoScore = 20 + rollTwo;
                        frameScoreList.Add(prevFrameTwoScore.ToString());
                        isStrikeTwo = false;
                    }

                    if (isStrike == true && rollOne != 10)
                    {
                        isStrike = false;
                        prevFrameScore = 10 + rollOne + rollTwo;
                        frameScoreList.Add(prevFrameScore.ToString());
                    }

                    if (isSpare != true && isStrike != true && isStrikeTwo != true) //neither strike nor spare
                    {
                        frameScore = rollOne + rollTwo;
                        frameScoreList.Add(frameScore.ToString());
                        i++; // advance to next frame
                    }
                }
                else //strike
                {
                    isStrike = true;
                }

                //10th frame, adding score to previous frame if strike
                if (frameCount == 10 && isStrike == true)
                {
                    if (i + 1 < rolls.Length)
                    {
                        if (rolls[i + 1] != "/" && rolls[i + 1] != "X")
                        {
                            rollTwo = int.Parse(rolls[i + 1]);
                        }
                        else if (rolls[i + 1] == "/")
                        {//if "/" entered we get value of that roll
                            rollTwo = 10 - int.Parse(rolls[i]);
                        }
                        else if (rolls[i + 1] == "X")
                        {
                            rollTwo = 10;
                        }
                    }

                    if (isStrikeTwo == true)
                    {
                        prevFrameTwoScore = 10 + 10 + rollTwo;
                        frameScoreList.Add(prevFrameTwoScore.ToString());
                        isStrikeTwo = false;
                    }
                }

                //extra roll on 10th frame
                if (frameCount == 10 && (isSpare == true || isStrike == true))
                {
                    if (i + 2 <= rolls.Length)
                    {
                        if (rolls[i + 2] != "X")
                        {
                            extraFrameScore = int.Parse(rolls[i  + 2]);
                        }
                        else
                        {
                            extraFrameScore = 10;
                        }

                        if (isStrike == true)
                        {
                            prevFrameScore = 10 + rollTwo + extraFrameScore;
                            frameScoreList.Add(prevFrameScore.ToString());
                        }
                        else
                        {
                            frameScore = 10 + extraFrameScore;
                            frameScoreList.Add(frameScore.ToString());
                        } 
                    }
                }
                frameCount++;
            }
            return frameScoreList.ToArray();
        }
    }
}