using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start1Player : MonoBehaviour
{
    public void game(string character)
    {
        PlayerPrefs.SetString("SelectedCharacter", character);
        SceneManager.LoadScene("Player1");
    }

}