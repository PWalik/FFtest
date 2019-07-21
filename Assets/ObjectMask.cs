using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMask : MonoBehaviour
{
    [SerializeField] Material innerMaskMaterial;
    [SerializeField] Renderer innerMaskGearRenderer;
    MaskController control;
    int id;
    public void InitMask(MaskController con, int i)
    {
        control = con;
        id = i;
    }

    public void MaskPlaced()
    {
        innerMaskGearRenderer.material = innerMaskMaterial;
        control.ReturnOtherMasks(id);
    }
}
