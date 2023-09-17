using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMobsMovement : MonoBehaviour {
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _changeDirectionRange = 0.5f;
    private Rigidbody2D _rb;
    public bool _canMove = true;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(_canMove) {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }

        float _direction;
        if(_speed < 0) _direction = -1;
        else _direction = 1;

        Debug.DrawRay(transform.position, Vector3.right * _direction * _changeDirectionRange, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * _direction, _changeDirectionRange);

        if(hit.collider != null && hit.collider.gameObject.tag == "Ground") ChangeDirection();
    }

    public void ChangeDirection() {
        _speed = -_speed;
    }

    public void GetPunched(int direction, float punchForce) {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        ChangeDirection();
        _rb.AddForce(Vector2.right * punchForce * direction, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
    }
}