using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _timerText;
    public PlayerController _player;
    private OffsetScrolling _offset;
    private SpawnManager _spawnManager;

    public Material[] BGmats;

    public float timer;
    public float BGchangeTime;
    float timeToChangeBool;

    private int _matNum = 0;
    bool hasChanged;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        _timerText = GetComponent<Text>();
        _spawnManager = FindObjectOfType<SpawnManager>();
        _offset = FindObjectOfType<OffsetScrolling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            if (_player.isActiveAndEnabled)
            {
                timer += Time.deltaTime;
                _timerText.text = timer.ToString("00");
                time = ((int)timer);

                if (time % BGchangeTime == 0 && !hasChanged)
                {
                    timeToChangeBool = 0;

                    if (_matNum < BGmats.Length)
                    {
                        _offset.ChangeBG(BGmats[_matNum]);
                    }
                    else
                    {
                        _matNum = 0;
                        _offset.ChangeBG(BGmats[_matNum]);
                    }
                    if (_spawnManager.interval > 0.5f)
                    {
                        _spawnManager.interval -= 0.1f;
                    }
                    hasChanged = true;
                    _matNum++;
                }

                timeToChangeBool += Time.deltaTime;
                if (timeToChangeBool > 1.5f)
                {
                    hasChanged = false;

                }
            }
        }
    }
}
