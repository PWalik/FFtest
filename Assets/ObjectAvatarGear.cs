using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAvatarGear : MonoBehaviour
{
    [System.NonSerialized] public ObjectAvatar avatar;
    [System.NonSerialized] public int id;
    bool isWearing;

    public bool IsWearing { get => isWearing; }

    public void StartWearing()
    {
        isWearing = true;
        avatar.GearActivated(id);

    }
}
