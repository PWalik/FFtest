using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script responsible for opening a single wardrobe
public class ObjectOpenable : MonoBehaviour
{
    [System.NonSerialized] public int wardrobeNumber;
    [System.NonSerialized] public ManageWardrobes master;
    [SerializeField] GameObject wardrobeContents;
    bool isOpen;

    public bool IsOpen { get => isOpen; }

    private void Start()
    {
        Close();
    }
    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;
        master.CloseAll(wardrobeNumber);
        wardrobeContents.SetActive(true);
    }

    public void Close()
    {
        isOpen = false;
        wardrobeContents.SetActive(false);
    }
}
