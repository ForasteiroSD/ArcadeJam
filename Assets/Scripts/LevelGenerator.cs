using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private Transform[] _patterns;
    [SerializeField] private int _floorsNumber;
    private Transform _startPosition;
    private Vector3 _lastEndPosition;

    private void Awake() {
        _startPosition = this.transform.GetChild(0).transform;
        _lastEndPosition = _startPosition.position;
        for(int i = 0; i < _floorsNumber - 1; i++) {
            Transform lastPlatform = SpawnLevelPart(_lastEndPosition);
            _lastEndPosition = lastPlatform.Find("EndPosition").position;
        }
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition) {
        Transform pattern = _patterns[UnityEngine.Random.Range(0, _patterns.Length)];
        spawnPosition += new Vector3(pattern.GetComponent<MeshCollider>().bounds.extents.x, 0, 0);
        Transform newPlatform = Instantiate(pattern, spawnPosition, Quaternion.identity);
        return newPlatform;
    }
}