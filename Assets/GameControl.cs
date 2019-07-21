using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class GameControl : MonoBehaviour
{
    float timer;
    bool isTimer = true;
    bool isWin = false;
    [SerializeField] GameObject spaceText;
    public float Timer { get => timer; }

    private void Update()
    {
        if(isTimer)
        timer += Time.deltaTime;

        if (isWin && Input.GetKeyDown(KeyCode.Space))
            GoNextStage();

    }
    
    public void Win()
    {
        isTimer = false;
        isWin = true;
        if(spaceText != null)
        spaceText.SetActive(true);
    }

    void GoNextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
