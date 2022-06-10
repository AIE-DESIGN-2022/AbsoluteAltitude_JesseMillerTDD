using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    public float timer;
    private PlayerController player;
    public Material[] BGmats;
    public float BGchangeTime;
    private OffsetScrolling offset;
    private int matNum = 0;
    int time;
    float timeToChangeBool;
    bool hasChanged;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        player = FindObjectOfType<PlayerController>();
        offset = FindObjectOfType<OffsetScrolling>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("00");
            time = ((int)timer);

            if(time % BGchangeTime == 0 && !hasChanged)
            {
                timeToChangeBool = 0;
                
                if(matNum < BGmats.Length)
                {
                    offset.ChangeBG(BGmats[matNum]);
                }
                else
                {
                    matNum = 0;
                    offset.ChangeBG(BGmats[matNum]);
                }
                hasChanged = true;
                matNum++;
            }
            
            timeToChangeBool += Time.deltaTime;
            if(timeToChangeBool > 1.5f)
            {
                hasChanged = false;

            }
        }
    }


}
