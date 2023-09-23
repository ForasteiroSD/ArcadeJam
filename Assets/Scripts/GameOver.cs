using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _canva;
    [SerializeField] private bool _isSinglePlayer;

    private void Start() {
        _isSinglePlayer = GameObject.Find("Zombies").GetComponent<ZombiesThrowBoost>().isSinglePlayer;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (_isSinglePlayer) {
            _canva.SetActive(true);
            GameObject.Find("Manager-GameOver").GetComponent<ShowScore>().ShowScoreText();
        }
        else {
            if(collision.gameObject.name == "Player1") SceneManager.LoadScene("Player1Win");
            else if(collision.gameObject.name == "Player2") SceneManager.LoadScene("Player2Win");
        }
    }
}