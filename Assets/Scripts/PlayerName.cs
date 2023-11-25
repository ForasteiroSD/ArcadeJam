using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerName : MonoBehaviour {
    private int _maxNameSize = 4;
    private string _playerName = "";
    private float _score;
    private CameraFollowPlayer _cameraFollowPlayer;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _warning;
    [SerializeField] private SaveManager _saveManager;

    private void Start() {
        _cameraFollowPlayer = Camera.main.GetComponent<CameraFollowPlayer>();
    }

    public void UpdatePlayerName(string newChar) {
        if(newChar == "delete") {
            if(_playerName.Length > 0) _playerName = _playerName.Substring(0, _playerName.Length-1);
        }
        else if(newChar == "aceitar") {
            _score = (_cameraFollowPlayer._currentMinutes * 60) + _cameraFollowPlayer._currentSeconds;
            _saveManager.UpdateHighScores(_playerName, _score);
            SceneManager.LoadScene("Main Menu");
        }
        else if(_playerName.Length < _maxNameSize) _playerName = string.Concat(_playerName, newChar);
        else StartCoroutine(MaxSizeReached(2f));
        _text.SetText(_playerName);
    }

    private IEnumerator MaxSizeReached(float time) {
        _warning.SetText("O tamanho máximo foi atingido!");
        yield return new WaitForSeconds(time);
        _warning.SetText("");
    }
}
