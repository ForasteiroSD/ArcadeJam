using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpike : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float spawnInterval;
    private float _timeElapsed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= spawnInterval)
        {
            _timeElapsed = 0.0f;
            float randomX = Random.Range(minX, maxX);

            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
            Vector3 rotation = new Vector3(0, 0, 180);
            Quaternion quaternionRotation = Quaternion.Euler(rotation);
            Instantiate(_prefab, spawnPosition,quaternionRotation);
        }
    }

}

