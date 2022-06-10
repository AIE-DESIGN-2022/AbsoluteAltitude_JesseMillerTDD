using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject endscreen;
    private float timer;
    private Timer timerScript;
    public Text scoreText;
    public bool gameOver;
    private HighScore HsManager;

    private void Start()
    {
        HsManager = FindObjectOfType<HighScore>();
        timerScript = FindObjectOfType<Timer>();
        endscreen.SetActive(false);
    }
    void Update()
    {
        if (player == null /*&& gameOver == false*/)
        {
            endscreen.SetActive(true);
            timer = timerScript.timer;
            GameOver();
        }

    }

    public void GameOver()
    {
        gameOver = true;
        if (HsManager.CheckHighScore(timer))
        {
            scoreText.text = "New High Score: " + timer.ToString("00");
        }

        else 
        {
            scoreText.text = "High Score: " + HsManager.highscore.ToString("00") + "\n" + "Your Score: " + timer.ToString("00"); 
        }
    }
}
