using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//master script for calculating all errors when shooting at walls
public class WallErrorController : MonoBehaviour
{
    [System.Serializable]
    public class Room
    {
         public ObjectShootable[] roomShootable;
    }

    [SerializeField] Room[] shootables;
    int totalMissed, totalOvershoot, totalShotWithWrong;
    int perfectRooms;
    //summs up all the errors and gives them to the KeepScore class
    public void CalculateScore()
    {
        for (int i = 0; i < shootables.Length; i++)
        {
            bool isRoomPerfect = true;
            for (int j = 0; j < shootables[i].roomShootable.Length; j++)
            {
                //if it was shot 0 times, we missed a wall
                if (shootables[i].roomShootable[j].TimesShot == 0)
                {
                    isRoomPerfect = false;
                    totalMissed++;
                }
                //if we shot it more than once, we shot it too much
                else if (shootables[i].roomShootable[j].TimesShot > 1)
                {
                    isRoomPerfect = false;
                    totalOvershoot += shootables[i].roomShootable[j].TimesShot - 1;
                }

                //adds to the count of shooting with the wrong rotation
                if (shootables[i].roomShootable[j].TimesShotWithWrong != 0)
                    isRoomPerfect = false;

                totalShotWithWrong += shootables[i].roomShootable[j].TimesShotWithWrong;
            }
            if (isRoomPerfect)
                perfectRooms++;
            
        }
        FindObjectOfType<KeepScore>().SaveErrorScores(totalMissed, totalOvershoot, totalShotWithWrong, perfectRooms);
    }

}
