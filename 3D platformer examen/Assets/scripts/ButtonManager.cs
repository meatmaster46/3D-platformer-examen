using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
    //main menu
    public void ButtonStartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonQuitGame()
    {
        Application.Quit();
    }
    //pause menu
    public void ButtonContinue()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void ButtonRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void ButtonReturnToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void ButtonNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}