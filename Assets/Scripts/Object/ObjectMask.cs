using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object script for masks - used together with MaskController to allow swapping the masks on the avatar
public class ObjectMask : MonoBehaviour
{
    [SerializeField] Material innerMaskMaterial;
    [SerializeField] Renderer innerMaskGearRenderer;
    MaskController control;
    int id;
    //initialize the mask from MaskController, giving the reference to the controller and the mask ID
    public void InitMask(MaskController con, int i)
    {
        control = con;
        id = i;
    }
    //after the mask is placed, give the color to the avatar's mask and return all other masks to their place
    public void MaskPlaced()
    {
        innerMaskGearRenderer.material = innerMaskMaterial;
        control.ReturnOtherMasks(id);
    }
}
