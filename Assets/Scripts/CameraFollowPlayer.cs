using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class CameraFollowPlayer : MonoBehaviour {
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [SerializeField] private CinemachineVirtualCamera _vcam;
    [SerializeField] private float _time = 60;
    [SerializeField] private float _cameraVelocity = 1f;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private float _maxHigh = 71f;
    [SerializeField] private bool _isSinglePlayer;
    [SerializeField] private float _delayForCamera = 3f;
    private float _initialTime;
    private float _currentTime = 0f;
    public float _currentMinutes;
    public float _currentSeconds;
    private bool _canFollow = true;

    // Update is called once per frame

    private void Start() {
        if(_isSinglePlayer) _delayForCamera += _currentTime;
        _initialTime = Time.time;
    }

    void Update() {
        _currentTime = Time.time - _initialTime;
        if(_isSinglePlayer) {
            _currentMinutes = Mathf.Floor((_currentTime)/60);
            _currentSeconds = Mathf.Floor(_currentTime - (_currentMinutes * 60));
            _timeText.SetText("Time: " + _currentMinutes + ":" + _currentSeconds.ToString("00"));

            if(_currentTime >= _delayForCamera) {
                transform.position = new Vector3(transform.position.x, transform.position.y + (_cameraVelocity * Time.deltaTime), transform.position.z);
            }
        } else {
            if(_player1.transform.position.y > _maxHigh || _player2.transform.position.y > _maxHigh) _canFollow = false;

            if(_time - _currentTime >= 0 && _canFollow) {
                if (_player1.transform.position.y > _player2.transform.position.y) _vcam.Follow = _player1.transform;
                else _vcam.Follow = _player2.transform;

                _currentMinutes = Mathf.Floor((_time - _currentTime)/60);
                _currentSeconds = Mathf.Floor(_time - _currentTime - (_currentMinutes * 60));
                _timeText.SetText("Time: " + _currentMinutes + ":" + _currentSeconds.ToString("00"));
            } else {
                _vcam.Follow = null;
                transform.position = new Vector3(transform.position.x, transform.position.y + (_cameraVelocity * Time.deltaTime), transform.position.z);
            }
        }
    }
}