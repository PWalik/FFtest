using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//master script for calculating all errors when shooting at walls
public class WallErrorController : MonoBehaviour
{
    [SerializeField] ObjectShootable[] shootables;
    int totalMissed, totalOvershoot, totalShotWithWrong;

    //summs up all the errors and gives them to the KeepScore class
    public void CalculateScore()
    {
        for (int i = 0; i < shootables.Length; i++)
        {
            //if it was shot 0 times, we missed a wall
            if (shootables[i].TimesShot == 0)
                totalMissed++;
            //if we shot it more than once, we shot it too much
            else if (shootables[i].TimesShot > 1)
                totalOvershoot += shootables[i].TimesShot - 1;

            //adds to the count of shooting with the wrong rotation
            totalShotWithWrong += shootables[i].TimesShotWithWrong;
        }
        FindObjectOfType<KeepScore>().SaveErrorScores(totalMissed, totalOvershoot, totalShotWithWrong);
    }

}
