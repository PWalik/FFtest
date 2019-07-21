using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controller for the gas masks - together with ObjectMask on each of the masks allows to swap and place masks on the avatar
public class MaskController : MonoBehaviour
{
    [SerializeField] GameObject[] masks;

    //at the start we initialize the masks with needed data - reference to this class and an ID
    private void Start()
    {
        for (int i = 0; i < masks.Length; i++)
        {
            masks[i].GetComponent<ObjectMask>().InitMask(this, i);
        }
    }

    //if we place a mask on the avatar, return others on their place on the shelf (so we can swap them out)
    public void ReturnOtherMasks(int id)
    {
        for (int i = 0; i < masks.Length; i++)
        {
            if (i != id)
                masks[i].SetActive(true);
        }
    }
}
