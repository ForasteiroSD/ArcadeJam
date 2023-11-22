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

        StartCoroutine(LoadLevel("Player1"));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void Player2()
    {
        transition.SetTrigger("Multiplayer");

        StartCoroutine(LoadLevel("Player2"));
    }
}
