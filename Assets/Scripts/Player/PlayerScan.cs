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

    void ScanOn()
    {
        scanningObject = select.selectedObject;
        scan = scanningObject.GetComponent<ObjectScannable>();
        if (scan == null)
            return;
        ObjectDoor door = scanningObject.GetComponent<ObjectDoor>();
        if(door != null)
        {
            if (door.isScannedOnce == false)
                door.isScannedOnce = true;
            else if (scan.number == 0)
                door.isScannedAfterNeutralise = true;
        }
        isScanning = true;
        UpdateUIText(scan.number.ToString());
        timerCoroutine = StartCoroutine(CountDown(readingsTimer));

        if (scanSound != null && audios != null)
        {
            audios.clip = scanSound;
            audios.Play();
        }
    }

    public void TurnOff()
    {
        ScanOff();
    }


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


    IEnumerator CountDown(float time)
    {
        float timer = 0f;
        Debug.Log("test");
        while(timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        ScanOff();
    }
    void UpdateUIText(string text)
    {
        numberUI.text = text;
    }
}
