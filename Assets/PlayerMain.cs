using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    PlayerRotateRing ring;
    PlayerScan scan;
    PlayerShoot shoot;
    PlayerOpen open;
    PlayerCast cast;
    PlayerSelect select;
    PlayerGameOver gameOver;

    public PlayerRotateRing Ring { get => ring; }
    public PlayerScan Scan { get => scan;}
    public PlayerShoot Shoot { get => shoot; }
    public PlayerOpen Open { get => open; }
    public PlayerCast Cast { get => cast; }
    public PlayerSelect Select { get => select; }
    public PlayerGameOver GameOver { get => gameOver;}

    private void Start()
    {
        ring = GetComponent<PlayerRotateRing>();
        scan = GetComponent<PlayerScan>();
        shoot = GetComponent<PlayerShoot>();
        open = GetComponent<PlayerOpen>();
        cast = GetComponent<PlayerCast>();
        select = GetComponent<PlayerSelect>();
        gameOver = GetComponent<PlayerGameOver>();
    }
}
