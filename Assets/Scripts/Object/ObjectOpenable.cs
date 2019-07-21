using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object script for openable wardrobes
public class ObjectOpenable : MonoBehaviour
{
    //current ID of the wardrobe
    [System.NonSerialized] public int wardrobeNumber;
    //master script managing the wardrobes 
    [System.NonSerialized] public ManageWardrobes master;
    //reference to the contents of the wardrobe
    [SerializeField] GameObject wardrobeContents;
    //is the wardrobe currently open?
    bool isOpen;

    public bool IsOpen { get => isOpen; }

    //at start, close the wardrobe
    private void Start()
    {
        Close();
    }

    //when we open one wardrobe, enable the wardrobeContents and let the master script know we need to close other wardrobes
    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;
        master.CloseAll(wardrobeNumber);
        wardrobeContents.SetActive(true);
    }

    //if we close the wardrobe, set the wardrobeContents as inactive
    public void Close()
    {
        isOpen = false;
        wardrobeContents.SetActive(false);
    }
}
