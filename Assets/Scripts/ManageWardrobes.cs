using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script responsible for managing all the wardrobes
public class ManageWardrobes : MonoBehaviour
{
    //check which wardrobe is currently open
    int currentlyOpen;
    //references to all the wardrobes ObjectOpenable classes
    [SerializeField] ObjectOpenable[] wardrobes;
    //initialize the wardrobes with their ID and reference to this class
    private void Start()
    {
        for (int i = 0; i < wardrobes.Length; i++)
        {
            wardrobes[i].wardrobeNumber = i;
            wardrobes[i].master = this;
        }
    }
    //close all wardrobes except the one that we are currently opening
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
