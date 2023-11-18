using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start2Player : MonoBehaviour
{
    private string selectedCharacterPlayer1;
    private string selectedCharacterPlayer2;

    public void SelectCharacterPlayer1(string character)
    {
        selectedCharacterPlayer1 = character;
        TryLoadMultiplayerScene();
    }

    public void SelectCharacterPlayer2(string character)
    {
        selectedCharacterPlayer2 = character;
        TryLoadMultiplayerScene();
    }

    private void TryLoadMultiplayerScene()
    {
        // Check if both players have made their selection
        if (!string.IsNullOrEmpty(selectedCharacterPlayer1) && !string.IsNullOrEmpty(selectedCharacterPlayer2))
        {
            // Save the selected characters and load the next scene
            PlayerPrefs.SetString("SelectedCharacterPlayer1", selectedCharacterPlayer1);
            PlayerPrefs.SetString("SelectedCharacterPlayer2", selectedCharacterPlayer2);
            SceneManager.LoadScene("Player2");
        }
    }

}
