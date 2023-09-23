using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private Transform[] _patterns;
    [SerializeField] private int _floorsNumber;
    private Transform _pattern;
    private Transform _startPosition;
    private Vector3 _lastEndPosition;

    private void Awake() {
        _startPosition = GameObject.Find("StartPosition").transform;
        _lastEndPosition = _startPosition.position;
        for(int i = 0; i < _floorsNumber - 1; i++) {
            if(i != _floorsNumber - 2) _pattern = _patterns[UnityEngine.Random.Range(0, _patterns.Length - 2)];
            else _pattern = _patterns[_patterns.Length - 1];
            Transform lastPlatform = SpawnLevelPart(_lastEndPosition);
            _lastEndPosition = lastPlatform.Find("EndPosition").position;
        }
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition) {
        spawnPosition += new Vector3(_pattern.GetComponent<MeshCollider>().bounds.extents.x, 0, 0);
        Transform newPlatform = Instantiate(_pattern, spawnPosition, Quaternion.identity);
        return newPlatform;
    }
}