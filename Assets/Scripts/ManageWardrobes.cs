using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script responsible for managing all the wardrobes

public class ManageWardrobes : MonoBehaviour
{
    int currentlyOpen;
    [SerializeField] ObjectOpenable[] wardrobes;
    private void Start()
    {
        for (int i = 0; i < wardrobes.Length; i++)
        {
            wardrobes[i].wardrobeNumber = i;
            wardrobes[i].master = this;
        }
    }
    public void CloseAll(int callingWardrobe)
    {
        if (callingWardrobe == currentlyOpen)
            return;
        currentlyOpen = callingWardrobe;
        for (int i = 0; i < wardrobes.Length; i++)
        {
            if (i != callingWardrobe)
                wardrobes[i].Close();
        }
    }
}
