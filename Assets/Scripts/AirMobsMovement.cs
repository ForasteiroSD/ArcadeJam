using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMobsMovement : MonoBehaviour {
    [SerializeField] private float _speed = 2f;
    [SerializeField] private bool _moveToRight;
    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        if(!_moveToRight) _speed = -_speed;
        else gameObject.GetComponent<SpriteRenderer>().flipX = true;

    }

    private void Update() {
        _rb.velocity = new Vector2(_speed, 0);
    }
}