using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMobsMovement : MonoBehaviour {
    [SerializeField] private float _speed = 2f;
    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }

    public void ChangeDirection() {
        _speed = -_speed;
    }
}