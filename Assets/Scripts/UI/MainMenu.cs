using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start() {
        Time.timeScale = 1;
    }

    public void Player1()
    {
        SceneManager.LoadScene("Player1");
    }
    public void Player2()
    {
        SceneManager.LoadScene("Player2");
    }
    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}