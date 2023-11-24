 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    [SerializeField] private float transitionTime = 1f;

    private void Start() {
        Time.timeScale = 1;
    }

    public void Player1()
    {
        transition.SetTrigger("SinglePlayer");

        StartCoroutine(LoadLevel("Player1Chosse"));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void GotToMainMenu() {
        transition.SetTrigger("Exit");

        StartCoroutine(LoadLevel("Main Menu"));
    }

    public void HighScores() {
        transition.SetTrigger("LeaderBoard");

        StartCoroutine(LoadLevel("HighScores"));
    }

    public void Player2()
    {
        transition.SetTrigger("Multiplayer");

        StartCoroutine(LoadLevel("Player2Chosse"));
    }
}
