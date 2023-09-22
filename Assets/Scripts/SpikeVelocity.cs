using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeVelocity : MonoBehaviour {
    [SerializeField] private float _velocity;
    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        _rb.velocity = new Vector2(0, -_velocity);
    }
}