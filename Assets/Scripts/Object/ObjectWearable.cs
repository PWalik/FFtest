using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objects script for objects that can be worn
public class ObjectWearable : MonoBehaviour
{
    //reference to the coresponding gear object on the avatar
    [SerializeField] ObjectAvatarGear woreObject;
    //reference to the coresponding collider indicator (the red/green box that shows you where to put the gear)
    [SerializeField] Transform colliderIndicator;

    public Transform ColliderIndicator { get => colliderIndicator; }

    //what happens when we drop the wearable object on the avatar at the correct position
    public void StartWearing()
    {
        ObjectMask mask = GetComponent<ObjectMask>();
        if(mask != null)
            mask.MaskPlaced();

        woreObject.gameObject.SetActive(true);
        woreObject.StartWearing();
        colliderIndicator.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    //start the indicator after we pick up the object
    public void StartIndicator()
    {
        colliderIndicator.gameObject.SetActive(true);
    }
    //stop indicator if we drop the object
    public void StopIndicator()
    {
        colliderIndicator.gameObject.SetActive(false);
    }
}
