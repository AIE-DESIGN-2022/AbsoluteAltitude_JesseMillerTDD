using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

    private SpawnManager _spawnManager;
    private OffsetScrolling _scrolling;
    public PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>(); 
        _playerController = FindObjectOfType<PlayerController>();
        _playerController.gameObject.SetActive(false);
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        MainMenu.SetActive(false); 
        _playerController.gameObject.SetActive(true);
        _spawnManager.isPlaying = true;
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        //SceneManager.LoadScene("MainScene");
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }

}
