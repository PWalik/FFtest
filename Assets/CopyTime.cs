using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
