using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _canva;
    [SerializeField] private bool _isSinglePlayer;
    [SerializeField] private Sprite _winImage;
    [SerializeField] private Image _imageBackground;

    private void Start() {
        _imageBackground = FindInActiveObjectByName("Image").GetComponent<Image>();
        _isSinglePlayer = GameObject.Find("Zombies").GetComponent<ZombiesThrowBoost>().isSinglePlayer;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (_isSinglePlayer) {
            _imageBackground.sprite = _winImage;
            _canva.SetActive(true);
            GameObject.Find("Manager-GameOver").GetComponent<ShowScore>().ShowScoreText();
        }
        else {
            _imageBackground.sprite = _winImage;
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