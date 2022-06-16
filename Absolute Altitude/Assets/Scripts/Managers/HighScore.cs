using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public ScriptableHighScore highScoreItem;
    public float highscore;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        highscore = highScoreItem.highScore;
    }

    public bool CheckHighScore(float score)
    {
        if(score > highscore)
        {
            highScoreItem.highScore = score;
            highscore= score;
            return true;
        }
        else
        {
            return false;
        }
    }
}
