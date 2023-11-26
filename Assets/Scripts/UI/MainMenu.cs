 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioSource SomTran;
    public Animator transition;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private Animator single;
    [SerializeField] private Animator multi;
    [SerializeField] private Animator high;

    private void Start() {
        SomTran = GameObject.Find("SomTran").GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    public void Player1()
    {
        transition.SetTrigger("SinglePlayer");
        SomTran.Play();
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
        SomTran.Play();
        StartCoroutine(LoadLevel("HighScores"));
    }

    public void Player2()
    {
        transition.SetTrigger("Multiplayer");
        SomTran.Play();
        StartCoroutine(LoadLevel("Player2Chosse"));
    }
}
