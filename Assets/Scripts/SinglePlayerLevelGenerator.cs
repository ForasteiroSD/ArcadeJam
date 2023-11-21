using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerLevelGenerator : MonoBehaviour {
    [SerializeField] private Transform[] _patterns;
    [SerializeField] private int _floorsNumber;
    private Transform _pattern;
    private Transform _startPosition;
    private Vector3 _lastEndPosition;

    private void Awake() {
        _startPosition = GameObject.Find("StartPosition").transform;
        _lastEndPosition = _startPosition.position;
        for(int i = 0; i < _patterns.Length; i++) {
            _pattern = _patterns[i];
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
