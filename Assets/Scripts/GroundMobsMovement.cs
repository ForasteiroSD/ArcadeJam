using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMobsMovement : MonoBehaviour {
    public AudioSource SomZumbi;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _changeDirectionRange = 0.5f;
    private Rigidbody2D _rb;
    private int _direction;
    public int direction => _direction;
    public bool _canMove = true;
    [SerializeField] private Animator _anim;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _anim.GetComponent<Animator>();
        SomZumbi = GameObject.Find("SomZumbi").GetComponent<AudioSource>();
    }

    private void Update() {
        if (_canMove) {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
            _anim.SetBool("Stunned", false);
        } else {
            _anim.SetBool("Stunned", true);
        }

        if (_speed < 0)
        {
            _direction = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else 
        { 
            _direction = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } 

        Debug.DrawRay(transform.position, Vector3.right * _direction * _changeDirectionRange, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * _direction, _changeDirectionRange);

        if(hit.collider != null && hit.collider.gameObject.tag == "Ground") ChangeDirection();
    }

    public void ChangeDirection() {
        _speed = -_speed;
    }

    public void GetPunched(int direction, float punchForce) {
        SomZumbi.Play();
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        ChangeDirection();
        _rb.AddForce(Vector2.right * punchForce * direction, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
    }
}