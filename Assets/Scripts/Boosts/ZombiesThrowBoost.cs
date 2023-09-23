using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesThrowBoost : MonoBehaviour {
    [SerializeField] private GameObject[] _boosts;
    [SerializeField] private float _timeBetweenBoosts = 10f;
    [SerializeField] private float _zombiesLength = 7.77f;
    [SerializeField] private bool _isSinglePlayer;
    public bool isSinglePlayer => _isSinglePlayer;
    private float _currentTime = 0f;
    private float _spawPosition;
    private float _defaulIncrease;
    private int _boostNumber;

    private void Start() {
        _defaulIncrease = _timeBetweenBoosts;
        _timeBetweenBoosts += Time.time;
    }

    private void Update() {
        _currentTime = Time.time;

        if(_currentTime >= _timeBetweenBoosts) {
            _spawPosition = Random.Range(-_zombiesLength, _zombiesLength);
            _boostNumber = Random.Range(0, _boosts.Length);

            Instantiate(_boosts[_boostNumber], new Vector3(_spawPosition, transform.position.y + 1, transform.position.z), Quaternion.identity);

            _timeBetweenBoosts += _defaulIncrease;
        }
    }
}