using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Object script for objects on the avatar - together with ObjectAvatar master script are responsible for placing the objects on the avatar
public class ObjectAvatarGear : MonoBehaviour
{
    //reference to the master controller script
    [System.NonSerialized] public ObjectAvatar avatar;
    //id of the gear
    [System.NonSerialized] public int id;
    //are we currently wearing this piece of gear?
    bool isWearing;

    public bool IsWearing { get => isWearing; }

    //if we drag a piece of gear onto the avatar, start wearing it and let the master script know
    public void StartWearing()
    {
        isWearing = true;
        avatar.GearActivated(id);

    }
}
