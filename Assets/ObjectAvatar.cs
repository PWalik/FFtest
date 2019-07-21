using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAvatar : MonoBehaviour
{
    [SerializeField] ObjectAvatarGear[] gear;
    [SerializeField] GameControl control;
    private void Start()
    {
        for (int i = 0; i < gear.Length; i++)
        {
            gear[i].id = i;
            gear[i].avatar = this;
        }
    }
    public void GearActivated(int id)
    {
        if (IsFullyClothed())
            control.Win();
    }


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
