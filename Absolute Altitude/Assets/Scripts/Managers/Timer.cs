using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    public float timer;
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("00");
        }
    }
}
