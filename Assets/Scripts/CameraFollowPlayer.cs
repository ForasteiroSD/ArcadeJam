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
    [SerializeField] private float _distanceToSpeedUpCamera = 3.5f;
    private float _initialTime;
    public float _currentTime = 0f;
    public float _currentSeconds;
    public bool _gameEnded = false;
    private bool _canFollow = true;

    private void Start() {
        if(_isSinglePlayer) _delayForCamera += _currentTime;
        _initialTime = Time.time;
    }

    void Update() {
        _currentTime = Time.time - _initialTime;
        //SinglePlayer
        if(_isSinglePlayer) {
            if(!_gameEnded) {
                //Change timer
                _currentSeconds = (float) System.Math.Round(_currentTime, 1);
                _timeText.SetText("Time: " + _currentSeconds + "s");

                //Camera movement
                if(_currentTime >= _delayForCamera) {
                    if(_player1.transform.position.y > transform.position.y + _distanceToSpeedUpCamera) {
                        float distance = _player1.transform.position.y - transform.position.y;
                        transform.position = new Vector3(transform.position.x, transform.position.y + ((_cameraVelocity + distance) * Time.deltaTime), transform.position.z);
                    }
                    else {
                        transform.position = new Vector3(transform.position.x, transform.position.y + (_cameraVelocity * Time.deltaTime), transform.position.z);
                    }
                }
            }

        //MultiPlayer
        } else {
            //Check wich player is higher
            if(_player1 != null && _player2 != null && (_player1.transform.position.y > _maxHigh || _player2.transform.position.y > _maxHigh)) _canFollow = false;

            //If time is not over yet or any player died
            if(_time - _currentTime >= 0 && _canFollow) {
                //Camera follow the highest player
                if (_player1.transform.position.y > _player2.transform.position.y) _vcam.Follow = _player1.transform;
                else _vcam.Follow = _player2.transform;

                //Change timer
                _currentSeconds = (float) System.Math.Round(_currentTime, 1);
                _timeText.SetText("Time: " + _currentSeconds + "s");
            }
            
            //Time is over or some player died
            else {
                _vcam.Follow = null;
                //Player 1 died
                if(_player1 == null) {
                    if(_player2.transform.position.y > transform.position.y + _distanceToSpeedUpCamera) {
                        float distance = _player2.transform.position.y - transform.position.y;
                        transform.position = new Vector3(transform.position.x, transform.position.y + ((_cameraVelocity + distance) * Time.deltaTime), transform.position.z);
                    }
                    else {
                        transform.position = new Vector3(transform.position.x, transform.position.y + (_cameraVelocity * Time.deltaTime), transform.position.z);
                    }
                }
                //Player 2 died
                else if(_player2 == null) {
                    if(_player1.transform.position.y > transform.position.y + _distanceToSpeedUpCamera) {
                        float distance = _player1.transform.position.y - transform.position.y;
                        transform.position = new Vector3(transform.position.x, transform.position.y + ((_cameraVelocity + distance) * Time.deltaTime), transform.position.z);
                    }
                    else {
                        transform.position = new Vector3(transform.position.x, transform.position.y + (_cameraVelocity * Time.deltaTime), transform.position.z);
                    }
                }
                //No player died
                else {
                    //Player 1 is higher
                    if(_player1.transform.position.y > transform.position.y + _distanceToSpeedUpCamera) {
                        float distance = _player1.transform.position.y - transform.position.y;
                        transform.position = new Vector3(transform.position.x, transform.position.y + ((_cameraVelocity + distance) * Time.deltaTime), transform.position.z);
                    }
                    //Player 2 is higher
                    else if(_player2.transform.position.y > transform.position.y + _distanceToSpeedUpCamera) {
                        float distance = _player2.transform.position.y - transform.position.y;
                        transform.position = new Vector3(transform.position.x, transform.position.y + ((_cameraVelocity + distance) * Time.deltaTime), transform.position.z);
                    }
                    //Default
                    else {
                        transform.position = new Vector3(transform.position.x, transform.position.y + (_cameraVelocity * Time.deltaTime), transform.position.z);
                    }
                }
            }
        }
    }

    public void FirstPlayerDied() {
        _canFollow =false;
    }
}