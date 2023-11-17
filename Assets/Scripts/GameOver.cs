using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _canva;
    [SerializeField] private bool _isSinglePlayer;
    // [SerializeField] private Sprite _winImage;
    // [SerializeField] private Image _imageBackground;
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _Score;
    private CameraFollowPlayer _cameraFollowPlayer;
    private float _currentMinutes;
    private float _currentSeconds;

    private void Start() {
        _cameraFollowPlayer = Camera.main.GetComponent<CameraFollowPlayer>();
        // _imageBackground = FindInActiveObjectByName("Image").GetComponent<Image>();
        _isSinglePlayer = GameObject.Find("Zombies").GetComponent<ZombiesThrowBoost>().isSinglePlayer;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (_isSinglePlayer) {
            Destroy(collision.gameObject);
            // _imageBackground.sprite = _winImage;
            _cameraFollowPlayer._gameEnded = true;
            _currentMinutes = _cameraFollowPlayer._currentMinutes;
            _currentSeconds = _cameraFollowPlayer._currentSeconds;
            _Score.SetText("Voce Venceu!! \n Seu Score foi: " + _currentMinutes + ":" + _currentSeconds.ToString("00"));

            _canva.SetActive(true);
            _startButton.Select();
            // GameObject.Find("Manager-GameOver").GetComponent<ShowScore>().ShowScoreText();
        }
        else {
            // _imageBackground.sprite = _winImage;
            if(collision.gameObject.name == "Player1") SceneManager.LoadScene("Player1Win");
            else if(collision.gameObject.name == "Player2") SceneManager.LoadScene("Player2Win");
        }
    }

    GameObject FindInActiveObjectByName(string name) {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++) {
            if (objs[i].hideFlags == HideFlags.None) {
                if (objs[i].name == name) {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}