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
    private bool _canFollow = true;
    public float _currentMinutes;
    public float _currentSeconds;

    // Update is called once per frame
    void Update() {
        if(_player1.transform.position.y > _maxHigh || _player2.transform.position.y > _maxHigh) _canFollow = false;

        if(_time - Time.time >= 0 && _canFollow) {
            if (_player1.transform.position.y > _player2.transform.position.y) _vcam.Follow = _player1.transform;
            else _vcam.Follow = _player2.transform;

            _currentMinutes = Mathf.Floor((_time - Time.time)/60);
            _currentSeconds = Mathf.Floor(_time - Time.time - (_currentMinutes * 60));
            _timeText.SetText("Time: " + _currentMinutes + ":" + _currentSeconds.ToString("00"));
        } else {
            _vcam.Follow = null;
            transform.position = new Vector3(transform.position.x, transform.position.y + (_cameraVelocity * Time.deltaTime), transform.position.z);
        }
    }
}