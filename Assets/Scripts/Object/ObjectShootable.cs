using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script on an object that can be shot at.
public class ObjectShootable : MonoBehaviour
{
    //how many times was it shot overall and how many with a wrong rotation of the ring. Is summed up at the end of the stage to calculate the score
    int timesShot = 0;
    int timesShotWithWrong = 0;
    ObjectScannable scan;
    private void Start()
    {
        scan = GetComponent<ObjectScannable>();
    }

    //called when the object is shot at
    public void Shoot(int ringNumber)
    {
        timesShot++;
        if (scan != null && scan.number != ringNumber)
            timesShotWithWrong++;
    }
}
