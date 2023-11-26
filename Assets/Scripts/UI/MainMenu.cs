 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioSource SomTran;
    public Animator transition;
    [SerializeField] private float transitionTime = 1f;

    private void Start() {
        if(GameObject.Find("SomTran") != null) {
            SomTran = GameObject.Find("SomTran").GetComponent<AudioSource>();
        }
        Time.timeScale = 1;
    }

    public void Player1()
    {
        SomTran.Play();
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
        SomTran.Play();
        transition.SetTrigger("LeaderBoard");

        StartCoroutine(LoadLevel("HighScores"));
    }

    public void Player2()
    {
        SomTran.Play();
        transition.SetTrigger("Multiplayer");

        StartCoroutine(LoadLevel("Player2Chosse"));
    }
}
