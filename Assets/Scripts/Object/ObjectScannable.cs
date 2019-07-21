using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object script that can be scanned with the scanner to read it's number
public class ObjectScannable : MonoBehaviour
{
    //current danger number of the object
    public int number;
    //min and max number possible, used for randomising the object
    [SerializeField] int minNumber, maxNumber;
    void Start()
    {
            RandomizeNumber();
    }
    //randomize the danger number
    void RandomizeNumber()
    {
        number = Random.Range(minNumber, maxNumber);
    }
}
