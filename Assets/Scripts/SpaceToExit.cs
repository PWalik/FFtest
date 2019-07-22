using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when you press space and it is active, end the game (either quit the editor, or close the app)
public class SpaceToExit : MonoBehaviour
{
    public bool isActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
            Exit();
    }

    private void Exit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
         Application.Quit();
    #endif
    }
}
