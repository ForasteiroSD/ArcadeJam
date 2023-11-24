using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start1Player : MonoBehaviour
{
    public Animator transition;
    [SerializeField] private float transitionTime = 1f;

    public void game(string character)
    {
        PlayerPrefs.SetString("SelectedCharacter", character);

        transition.SetTrigger("Play");
        StartCoroutine(LoadLevel("Player1"));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}