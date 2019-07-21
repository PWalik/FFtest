using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//script responsible for controlling the main game - timers, win scenarios etc
public class GameControl : MonoBehaviour
{
    //how long did the stage take us
    float timer;
    //should the timer be counting
    bool isTimer = true;
    //have we won the game
    bool isWin = false;
    //"Press space!" UI text reference
    [SerializeField] GameObject spaceText;
    public float Timer { get => timer; }

    private void Update()
    {
        if(isTimer)
        timer += Time.deltaTime;

        if (isWin && Input.GetKeyDown(KeyCode.Space))
            GoNextStage();

    }
    //what happens once we complete all the win requirements
    public void Win()
    {
        isTimer = false;
        isWin = true;
        if(spaceText != null)
        spaceText.SetActive(true);
    }
    //after we win and press space, go to the next stage (saving the score)
    void GoNextStage()
    {
        FindObjectOfType<KeepScore>().SaveTimer(timer);
        WallErrorController wall = GetComponent<WallErrorController>();
        if (wall != null)
            wall.CalculateScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
