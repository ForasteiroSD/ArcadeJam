using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Player1()
    {
        SceneManager.LoadScene("Player1");
    }
    public void Player2()
    {
        SceneManager.LoadScene("Player2");
    }
}