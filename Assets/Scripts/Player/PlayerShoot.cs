using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script on the player object responsible for shooting the neutralizer
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] AudioClip shootSound;
    PlayerRotateRing ring;
    PlayerSelect select;
    PlayerScan scan;
    AudioSource audios;
    //on start we take the references for all the needed scripts on the player objects 
    private void Start()
    {
        ring = GetComponent<PlayerRotateRing>();
        select = GetComponent<PlayerSelect>();
        scan = GetComponent<PlayerScan>();
        audios = GetComponent<AudioSource>();
    }
    
    public void Shoot()
    {
        //if we cannot find some of the needed scripts, we return
        if (ring == null || select == null || scan == null || select.selectedObject == null)
            return;

        ObjectScannable objectScan = select.selectedObject.GetComponent<ObjectScannable>();

        if (objectScan == null)
            return;

        ObjectShootable objectShoot = select.selectedObject.GetComponent<ObjectShootable>();

        if (objectShoot == null)
            return;
        //we call the objects Shoot function (so it can count in the score summary)
        objectShoot.Shoot(ring.CurrRing);

        //if we shot with the correct ring rotation, we neutralise the object
        if (ring.CurrRing == objectScan.number)
        {
            objectScan.number = 0;
        }
        //we turn off the scanning window if it's still up, so we have to scan again to make sure the object is neutralised
        scan.TurnOff();

        //if we have the audio components, play the shooting sound
        if(shootSound != null && audios != null)
        {
            audios.clip = shootSound;
            audios.Play();
        }
           

    }
}
