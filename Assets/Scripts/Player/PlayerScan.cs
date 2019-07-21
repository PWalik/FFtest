using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script responsible for performing a scan of the object's scan number
public class PlayerScan : MonoBehaviour
{
    PlayerSelect select;
    GameObject scanningObject;
    ObjectScannable scan;
    AudioSource audios;
    //check if we are currently scanning any object
    bool isScanning;
    //reference to the UI text component showing us the number
    [SerializeField] Text numberUI;
    //how many seconds should the reading be up on the screen
    [SerializeField] float readingsTimer;
    //clip that should play when the scan is executed
    [SerializeField] AudioClip scanSound;
    Coroutine timerCoroutine;

    void Start()
    {
        select = GetComponent<PlayerSelect>();
        audios = GetComponent<AudioSource>();
    }

    void Update()
    {
    if (isScanning && select.selectedObject != scanningObject)
        {
            ScanOff();
        }
    }

    public void Scan()
    {
        if (select != null && select.isLit && isScanning == false)
        {
            ScanOn();
        }
    }

    //turn on the scan
    void ScanOn()
    {
        scanningObject = select.selectedObject;
        scan = scanningObject.GetComponent<ObjectScannable>();
        if (scan == null)
            return;
        //if it's a door, check if we scanned it before and after neutralisation
        ObjectDoor door = scanningObject.GetComponent<ObjectDoor>();
        if(door != null)
        {
            if (door.isScannedOnce == false)
                door.isScannedOnce = true;
            else if (scan.number == 0)
                door.isScannedAfterNeutralise = true;
        }
        isScanning = true;
        //get the scanning readout on the scanner screen
        UpdateUIText(scan.number.ToString());
        //start a coroutine that keeps the scan readout up on the screen for readingsTimer seconds
        timerCoroutine = StartCoroutine(CountDown(readingsTimer));

        //if we have audio components, play the scanning sound
        if (scanSound != null && audios != null)
        {
            audios.clip = scanSound;
            audios.Play();
        }
    }


    //turn off the scan
    public void TurnOff()
    {
        ScanOff();
    }

    //what happens when we turn off the scan
    void ScanOff()
    {
        isScanning = false;
        scanningObject = null;
        scan = null;
        UpdateUIText("");
        if(timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    //count down, after which turn off the scan
    IEnumerator CountDown(float time)
    {
        float timer = 0f;
        while(timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        ScanOff();
    }
    //update the UI text of the scan readout from string
    void UpdateUIText(string text)
    {
        numberUI.text = text;
    }
}
