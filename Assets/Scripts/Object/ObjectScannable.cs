using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScannable : MonoBehaviour
{
    public int number;
    [SerializeField] int minNumber, maxNumber;
    // Start is called before the first frame update
    void Start()
    {
        int tries = 0;
        while (number == 0 && tries < 100)
        {
            RandomizeNumber();
            tries++;
        }
    }
    void RandomizeNumber()
    {
        number = Random.Range(minNumber, maxNumber);
    }
}
