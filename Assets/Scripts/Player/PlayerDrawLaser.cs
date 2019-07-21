using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawLaser : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] LineRenderer line;
    PlayerCast cast;

    private void Start()
    {
        cast = GetComponent<PlayerCast>();
        line.SetPosition(0, startPoint.position);
    }
    void FixedUpdate()
    {
        line.SetPosition(1, cast.Point);
    }
}
