using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private Animator _anim;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 3f;
    private float _defaultSpeed;
    [SerializeField] private bool _isPlayer1;
    public bool isPlayer1 => _isPlayer1;
    private float _directionX;
    [SerializeField] private float _jumpHeight = 2.5f;
    [SerializeField] private float _fallGravityScaleMultiplier = 3f;
    [SerializeField] private float _timeToJump = .15f;
    private GameObject _ground;
    public bool _canMove = true;
    private bool _canJump = true;
    private bool _stuned = false;
    private float _gravityScale;
    private float _fallGravityScale;
    private float _jumpForce;
    private bool _isJumping = false;
    [SerializeField] private bool _doubleJump = false;
    private int _lookingDirection; //-1 -> left, 1 -> right
    public int lookingDirection => _lookingDirection;
    private Coroutine _adrenalineRoutine;
    public AudioSource SomJeff;
    public AudioSource SomNicole;
    public AudioSource SomMola;

    private void Start()
    {
        SomMola = GameObject.Find("SomMola").GetComponent<AudioSource>();
        SomJeff = GameObject.Find("SomJeff").GetComponent<AudioSource>();
        SomNicole = GameObject.Find("SomNicole").GetComponent<AudioSource>();
    }
    
    private void Awake() {
        //GetComponents
        _rb = GetComponent<Rigidbody2D>();

        //Jump
        _gravityScale = _rb.gravityScale;
        _fallGravityScale = _rb.gravityScale * _fallGravityScaleMultiplier;
        _rb.gravityScale = _fallGravityScale;
        _ground = transform.GetChild(0).gameObject;

        //Move
        if(_isPlayer1) _lookingDirection = 1;
        else _lookingDirection = -1;
        _defaultSpeed = _speed;
    }

    private void Update() {
        //Move
        if(Input.GetAxis("Horizontal1") != 0 && _isPlayer1 && _canMove && !_stuned){
            _directionX = Input.GetAxis("Horizontal1");
            Move(_directionX);
        } else if(Input.GetAxis("Horizontal2") != 0 && !_isPlayer1 && _canMove && !_stuned){
            _directionX = Input.GetAxis("Horizontal2");
            Move(_directionX);
        }

        //Double jump
        if(_doubleJump && !_canJump && !_stuned && ((Input.GetKeyDown(KeyCode.W) && _isPlayer1) || (Input.GetKeyDown(KeyCode.UpArrow) && !_isPlayer1))) DoubleJump();
        
        //Normal jump
        if(_canJump && !_stuned && ((Input.GetKeyDown(KeyCode.W) && _isPlayer1) || (Input.GetKeyDown(KeyCode.UpArrow) && !_isPlayer1))) Jump();

        //Start falling
        if(_isJumping) {
            if(_rb.velocity.y >= 1.7f && Input.GetKeyUp(KeyCode.W) && _isPlayer1) {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y/2);
                _rb.gravityScale = _fallGravityScale;
            }
            else if(_rb.velocity.y >= 1.7f && Input.GetKeyUp(KeyCode.UpArrow) && !_isPlayer1) {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y/2);
                _rb.gravityScale = _fallGravityScale;
            }
            if (_rb.velocity.y < 0) { 
                _rb.gravityScale = _fallGravityScale;
                _anim.SetBool("IsFalling", true);
            }
            else
            {
                _anim.SetBool("IsFalling", false);
            }
        }

        _anim.SetBool("CanJump", _canJump);
        

        // Animacao
        if (lookingDirection == 1) gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else gameObject.GetComponent<SpriteRenderer>().flipX = true;
        if (_isPlayer1)
        {
            if (Input.GetAxis("Horizontal1") != 0 && _canMove && !_stuned) _anim.SetBool("IsMoving", true);
            else _anim.SetBool("IsMoving", false);
        }
        else
        {
            if (Input.GetAxis("Horizontal2") != 0 && _canMove && !_stuned) _anim.SetBool("IsMoving", true);
            else _anim.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        //Reset canJump
        if(collider.tag == "Ground") {
            _canJump = true;
            _isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        //Cancel canJump
        if(gameObject.activeInHierarchy && collider.tag == "Ground") StartCoroutine(CancelCanJump());
    }

    private void Move(float moveDirection) {
        _rb.velocity = new Vector2(moveDirection * _speed, _rb.velocity.y);
        if(moveDirection > 0) _lookingDirection = 1;
        else if(moveDirection < 0) _lookingDirection = -1;
    }

    public void Adrenaline(float duration, float multiplier) {
        _anim.SetTrigger("Adrenalina");
        _speed = _speed * multiplier;
        _adrenalineRoutine = StartCoroutine(StopAdrenaline(duration));
    }

    private IEnumerator StopAdrenaline(float duration) {
        yield return new WaitForSeconds(duration);

        _speed = _defaultSpeed;
        ResetBoostIcon();
    }

    public void CancelAdrenaline() {
        if(_adrenalineRoutine != null) StopCoroutine(_adrenalineRoutine);
        _speed = _defaultSpeed;
    }

    private void Jump() {
        _rb.gravityScale = _gravityScale;

        if (_canJump && !_stuned && ((Input.GetKeyDown(KeyCode.W) && _isPlayer1)))
        {
            SomJeff.Play();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !_isPlayer1) {
            SomNicole.Play();
        }

        _anim.SetTrigger("JUMP");
        _jumpForce = (float) Math.Sqrt(_jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _isJumping = true;
        _canJump = false;
    }

    private void DoubleJump() {
        _anim.SetTrigger("DoblueJump");
        _isJumping = true;
        _rb.gravityScale = _gravityScale;
        _jumpForce = (float) Math.Sqrt(_jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        SomMola.Play();
        _doubleJump = false;
        ResetBoostIcon();
    }

    public void EnableDoubleJump() {
        _doubleJump = true;
    }

    public void CancelDoubleJump() {
        _doubleJump = false;
    }

    IEnumerator CancelCanJump() {
        yield return new WaitForSeconds(_timeToJump);
        _canJump = false;
    }

    public void Stun(float timeStuned) {
        _stuned = true;
        _anim.SetBool("Stun", true);
        StartCoroutine(CancelStun(timeStuned));
    }

    IEnumerator CancelStun(float timeStuned) {
        yield return new WaitForSeconds(timeStuned);
        _anim.SetBool("Stun", false);
        _stuned = false;
    }

    private void ResetBoostIcon() {
        if(_isPlayer1) GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "none");
        else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "none");
    }

    public void GetPunched(float direction, float punchForce)
    {
        _rb.AddForce(Vector2.right * punchForce * direction, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.up * punchForce * 3, ForceMode2D.Impulse);
    }
}