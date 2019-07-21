using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWearable : MonoBehaviour
{
    [SerializeField] ObjectAvatarGear woreObject;
    [SerializeField] Transform colliderIndicator;

    public Transform ColliderIndicator { get => colliderIndicator; }

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

    public void StartIndicator()
    {
        colliderIndicator.gameObject.SetActive(true);
    }
}
