using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//master script for the Avatar Object - manages all the gear, and checks for the win condition once the gear is placed
public class ObjectAvatar : MonoBehaviour
{
    //reference to all the gear able to be placed on the avatar
    [SerializeField] ObjectAvatarGear[] gear;
    //reference to the GameControl class
    [SerializeField] GameControl control;

    //initialise the gear, giving the id and the reference to this class
    private void Start()
    {
        for (int i = 0; i < gear.Length; i++)
        {
            gear[i].id = i;
            gear[i].avatar = this;
        }
    }
    //check the win condition, if we win - let the GameControl know
    public void GearActivated(int id)
    {
        if (IsFullyClothed())
            control.Win(0);
    }

    //checks if we have all the clothes on the avatar
    bool IsFullyClothed()
    {
        for (int i = 0; i < gear.Length; i++)
        {
            if (gear[i].IsWearing == false)
                return false;
        }
        return true;
    }

}
