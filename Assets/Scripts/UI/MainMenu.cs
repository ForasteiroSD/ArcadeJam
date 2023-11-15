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
        SceneManager.LoadScene(1);
    }
    public void Player2()
    {
        SceneManager.LoadScene("Player2");
    }
}
