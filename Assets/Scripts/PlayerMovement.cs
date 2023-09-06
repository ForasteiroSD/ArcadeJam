using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D _rb;
    [SerializeField] private bool _isPlayer1;
    [SerializeField] private float _speed = 3f;
    private float _directionX;
    [SerializeField] private float _jumpHeight = 2.5f;
    // [SerializeField] private float _jumpTime = 0.25f;
    [SerializeField] private float _fallGravityScaleMultiplier = 3f;
    [SerializeField] private float _timeToJump = .15f;
    private GameObject _ground;
    private bool _canJump = true;
    private float _gravityScale;
    private float _fallGravityScale;
    private float _jumpForce;
    private bool _isJumping = false;
    // private float _jumpStartTime;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _gravityScale = _rb.gravityScale;
        _fallGravityScale = _rb.gravityScale * _fallGravityScaleMultiplier;
        _rb.gravityScale = _fallGravityScale;
        _ground = transform.GetChild(0).gameObject;
    }

    private void Update() {
        //Move
        if((Input.GetAxis("Horizontal1") != 0 && _isPlayer1)){
            _directionX = Input.GetAxis("Horizontal1");
            Move(_directionX);
        } else if((Input.GetAxis("Horizontal2") != 0 && !_isPlayer1)){
            _directionX = Input.GetAxis("Horizontal2");
            Move(_directionX);
        }
        
        //Jump
        if(((Input.GetKeyDown(KeyCode.W) && _isPlayer1) || (Input.GetKeyDown(KeyCode.UpArrow) && !_isPlayer1)) && _canJump) Jump();
        if(_isJumping) {
            if(_rb.velocity.y >= 1.7f && Input.GetKeyUp(KeyCode.W) && _isPlayer1) _rb.gravityScale = _fallGravityScale;
            else if(_rb.velocity.y >= 1.7f && Input.GetKeyUp(KeyCode.UpArrow) && !_isPlayer1) _rb.gravityScale = _fallGravityScale;
            if(_rb.velocity.y < 1.7f) {
                _rb.gravityScale = _fallGravityScale;
                _isJumping = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        //Reset canJump
        if(collider.tag == "Ground") _canJump = true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        //Cancel canJump
        if(gameObject.activeInHierarchy && collider.tag == "Ground") StartCoroutine(CancelCanJump());
    }

    private void Move(float moveDirection) {
        _rb.velocity = new Vector2(moveDirection * _speed, _rb.velocity.y);
    }

    private void Jump() {
        _rb.gravityScale = _gravityScale;
        _jumpForce = (float) Math.Sqrt(_jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) *_rb.mass;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _isJumping = true;
        _canJump = false;
    }

    IEnumerator CancelCanJump() {
        yield return new WaitForSeconds(_timeToJump);
        _canJump = false;
    }
}