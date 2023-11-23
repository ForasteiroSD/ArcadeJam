using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MORTE : MonoBehaviour
{
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _gameOver;
    private bool _isSinglePlayer;
    private Rigidbody2D _rb;
    private float _timeElapsed;
    [SerializeField] private bool _firstPlayerDied = false;
    [SerializeField] private Button _restartButton;

    private void OnEnable() {
        _firstPlayerDied = false;
    }

    private void Start() {
        _isSinglePlayer = GameObject.Find("Zombies").GetComponent<ZombiesThrowBoost>().isSinglePlayer;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(_isSinglePlayer) {
            if(collision.gameObject.name == "Player1") {
                _hud.SetActive(false);
                _gameOver.SetActive(true);
                Time.timeScale = 0;
                _restartButton.Select();
            }
        } else {
            if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2") {
                if(_firstPlayerDied == false) {
                    _firstPlayerDied = true;
                    _timeElapsed = Time.time;
                    this.transform.parent.gameObject.GetComponent<CameraFollowPlayer>().FirstPlayerDied();
                    Destroy(collision.gameObject);
                    return;
                }
                else if(_firstPlayerDied == true && Time.time >= _timeElapsed + 0.2f) {
                    _hud.SetActive(false);
                    _gameOver.SetActive(true);
                    Time.timeScale = 0;
                    _restartButton.Select();
                }
            } 
        }
    }
}