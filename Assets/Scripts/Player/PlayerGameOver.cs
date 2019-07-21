using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Player script responsible for the gameOver state in stage 2 and losing lives
public class PlayerGameOver : MonoBehaviour
{
    //current lives value - if it falls to 0, we lose
    int lives = 3;
    //starting position and rotation of the player (so it can be reset if he loses a life
    Vector3 position;
    Quaternion rotation;
    GameControl control;
    private void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
        control = FindObjectOfType<GameControl>();
    }

    //called out everytime we should lose a life (so when we open the door without checking it, if we shoot with a wrong value or if we open the door after shooting without checking it first)
    public void LoseLife()
    {
        lives--;
        ResetPlayerPosition();
        if(lives <= 0)
        {
            GameOver();
        }
    }

    void ResetPlayerPosition()
    {
        transform.position = position;
        transform.rotation = rotation;
    }

    public bool CheckIfLoseLife(GameObject selectedGameObject, int ringValue)
    {

        ObjectDoor door = selectedGameObject.GetComponent<ObjectDoor>();

        if (door != null && (door.isScannedAfterNeutralise == false || door.isScannedOnce == false))
            return true;


        return false;
    }

    //after winning stage 2, go into stage 3 (score summary) with all the data about mistakes/time/etc
    public void Win()
    {
        control.Win();
    }

    //what happens when you get to 0 lives. Right now it stops the application, but in the real program it will prob lead to a game over screen/different scene
    void GameOver()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
