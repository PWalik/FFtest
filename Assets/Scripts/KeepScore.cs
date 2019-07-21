using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script responsible for keeping the score and errors from stages 1 and 2
public class KeepScore : MonoBehaviour
{
    //time it took the player to complete stages 1 and 2
    [System.NonSerialized] float stage1time, stage2time;
    //how many lives the player lost, how many walls did he miss, how many did he shoot to many times, and how many with a wrong rotation setting
    [System.NonSerialized] int livesLost, wallsMissed, wallsShotMultiple, wallsShotWithWrong;
    //check so we know if we should take stage1 or stage 2 information
    bool isStageOne = true;

    public bool IsStageOne { get => isStageOne; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //used to save the timer value across the stages
    public void SaveTimer(float time)
    {
        if (isStageOne)
        {
            stage1time = time;
            isStageOne = false;
        }
        else stage2time = time;
    }

    //save the lives we lost during stage 2
    public void SaveLives(int livesLoss)
    {
        livesLost = livesLoss;
    }

    //save the errors we made during stage 2
    public void SaveErrorScores(int missed, int multiple, int wrong)
    {
        wallsMissed = missed;
        wallsShotMultiple = multiple;
        wallsShotWithWrong = wrong;
    }
}
