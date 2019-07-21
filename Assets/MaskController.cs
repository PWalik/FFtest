using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    [SerializeField] GameObject[] masks;


    private void Start()
    {
        for (int i = 0; i < masks.Length; i++)
        {
            masks[i].GetComponent<ObjectMask>().InitMask(this, i);
        }
    }
    public void ReturnOtherMasks(int id)
    {
        for (int i = 0; i < masks.Length; i++)
        {
            if (i != id)
                masks[i].SetActive(true);
        }
    }
}
