using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MORTE : MonoBehaviour
{
    [SerializeField] private float _velocityY;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _gameOver;
    private bool _isSinglePlayer;
    private Rigidbody2D _rb;
    private float _timeElapsed;

    private void Start() {
        _isSinglePlayer = GameObject.Find("Zombies").GetComponent<ZombiesThrowBoost>().isSinglePlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isSinglePlayer) {
            if(collision.gameObject.name == "Player1") {
                _hud.SetActive(false);
                _gameOver.SetActive(true);
                Time.timeScale = 0;
            }
        } else {
            if(collision.gameObject.name == "Player1") SceneManager.LoadScene("Player1Win");
            if(collision.gameObject.name == "Player2") SceneManager.LoadScene("Player2Win");
        }
        
    }
}
