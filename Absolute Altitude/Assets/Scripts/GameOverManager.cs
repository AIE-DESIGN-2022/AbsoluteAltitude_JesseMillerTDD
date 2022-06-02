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

    private void Start()
    {
        timerScript = FindObjectOfType<Timer>();
    }
    void Update()
    {
        if (player == null)
        {
            endscreen.SetActive(true);
            timer = timerScript.timer;
            scoreText.text = "Score: " + timer.ToString("00");
        }

        else
        {
            endscreen.SetActive(false);
        }
    }
}
