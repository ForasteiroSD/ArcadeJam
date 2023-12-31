using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start2Player : MonoBehaviour
{
    public Animator transition;
    [SerializeField] private float transitionTime = 1f;
    public static string selectedCharacterPlayer1;
    public static string selectedCharacterPlayer2;

    public void Start() {
        selectedCharacterPlayer1 = null;
        selectedCharacterPlayer2 = null;
    }

    public void SelectCharacterPlayer1(string character)
    {
        // Debug.Log("Player2 Selecionou");
        selectedCharacterPlayer1 = character;
        TryLoadMultiplayerScene(selectedCharacterPlayer1,selectedCharacterPlayer2);
    }

    public void SelectCharacterPlayer2(string character)
    {
        // Debug.Log("Player1 Selecionou");
        selectedCharacterPlayer2 = character;
        TryLoadMultiplayerScene(selectedCharacterPlayer1,selectedCharacterPlayer2);
    }

    private void TryLoadMultiplayerScene(string p1, string p2)
    {
        // Debug.Log(selectedCharacterPlayer1);
        // Debug.Log(selectedCharacterPlayer2);

        // Check if both players have made their selection
        if (!string.IsNullOrEmpty(p1) && !string.IsNullOrEmpty(p2))
        {
            // Debug.Log("VAMO FI");
            // Save the selected characters and load the next scene
            PlayerPrefs.SetString("SelectedCharacterPlayer1", p1);
            PlayerPrefs.SetString("SelectedCharacterPlayer2", p2);
            
            transition.SetTrigger("Play");
            StartCoroutine(LoadLevel("Player2"));
        }
    }

    IEnumerator LoadLevel(string sceneName)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
