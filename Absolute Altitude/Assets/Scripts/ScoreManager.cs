using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject timerText;
    public static float score = 0;

    private void Start()
    {
        setscore(0);
    }

    public void setscore(float scoretoadd)
    {
        score += scoretoadd;
        timerText.ToString();
    }
}