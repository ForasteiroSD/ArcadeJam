using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start2Player : MonoBehaviour
{
    private static string selectedCharacterPlayer1;
    private static string selectedCharacterPlayer2;

    public void SelectCharacterPlayer1(string character)
    {
        Debug.Log("Player2 Selecionou");
        selectedCharacterPlayer1 = character;
        TryLoadMultiplayerScene(selectedCharacterPlayer1,selectedCharacterPlayer2);

    }

    public void SelectCharacterPlayer2(string character)
    {
        Debug.Log("Player1 Selecionou");
        selectedCharacterPlayer2 = character;
        TryLoadMultiplayerScene(selectedCharacterPlayer1,selectedCharacterPlayer2);
    }

    private void TryLoadMultiplayerScene(string p1, string p2)
    {
        Debug.Log(selectedCharacterPlayer1);
        Debug.Log(selectedCharacterPlayer2);
        // Check if both players have made their selection
        if (!string.IsNullOrEmpty(p1) && !string.IsNullOrEmpty(p2))
        {
            Debug.Log("VAMO FI");
            // Save the selected characters and load the next scene
            PlayerPrefs.SetString("SelectedCharacterPlayer1", p1);
            PlayerPrefs.SetString("SelectedCharacterPlayer2", p2);
            SceneManager.LoadScene("Player2");
        }
    }

}
