using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script reading the value of the timer on GameControl and copies it into the UI text component
public class CopyTime : MonoBehaviour
{
    [SerializeField] GameControl control;
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        text.text = control.Timer.ToString("F1");
    }
}
