using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject endscreen;

    void Update()
    {
        if (player == null)
        {
            endscreen.SetActive(true);
        }

        else
        {
            endscreen.SetActive(false);
        }
    }
}
