using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
    public AudioSource SomSoco;
    public AudioSource SomTaco;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _delayToPunch = 2f;
    [SerializeField] private float _punchForce = 1f;
    [SerializeField] private float _punchRange = 1f;
    private float _defaultPunchForce;
    private Ray _ray;
    private bool _isPlayer1;
    private bool _canPunch = true;
    private float _lastPunchTime = 0f;
    private int _punchDirection = 1;
    private Rigidbody2D _rb;


    private void Start() {
        SomSoco = GameObject.Find("SomSoco").GetComponent<AudioSource>();
        SomTaco = GameObject.Find("SomTaco").GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        if(this.GetComponent<PlayerMovement>() != null) _isPlayer1 = this.GetComponent<PlayerMovement>().isPlayer1;
        _defaultPunchForce = _punchForce;
    }

    private void Update() {
        _punchDirection = this.GetComponent<PlayerMovement>().lookingDirection; 
        Debug.DrawRay(transform.position, Vector3.right * _punchDirection * _punchRange, Color.green);
        if(Time.time - _lastPunchTime > _delayToPunch) _canPunch = true;

        if(((_isPlayer1 && Input.GetKeyDown(KeyCode.Space)) || (!_isPlayer1 && Input.GetKeyDown(KeyCode.Return))) && _canPunch) {
            _canPunch = false;
            _lastPunchTime = Time.time;
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * _punchDirection, _punchRange);

            //HitPlayer
            if(hit.collider != null && hit.collider.gameObject.tag == "Player") {
                GameObject player = hit.collider.gameObject;
                if(_punchForce != _defaultPunchForce) DelayToMovePlayer(player, 1f);
                else DelayToMovePlayer(player, 0.5f);

                // animacao
                if (_punchForce != _defaultPunchForce)
                {
                    _anim.SetTrigger("PunchBaseball");
                    _anim.SetBool("Baseball", false);
                    SomTaco.Play();
                }
                else _anim.SetTrigger("Punch"); 
                //
                player.GetComponent<Punch>().GetPunched(_punchDirection, _punchForce);

                if(_punchForce != _defaultPunchForce) {
                    _punchForce = _defaultPunchForce;
                    if(_isPlayer1) GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "none");
                    else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "none");
                }
            }

            //HitZombie
            else if(hit.collider != null && hit.collider.gameObject.tag == "Enemy") {
                GameObject enemy = hit.collider.gameObject.transform.parent.gameObject;
                if(_punchForce != _defaultPunchForce) DelayToMoveMob(enemy, 1f);
                else DelayToMoveMob(enemy, 0.5f);
                // animacao
                if (_punchForce != _defaultPunchForce)
                {
                    _anim.SetTrigger("PunchBaseball");
                    _anim.SetBool("Baseball", false);
                    SomTaco.Play();
                }
                else _anim.SetTrigger("Punch");
                //
                enemy.GetComponent<GroundMobsMovement>().GetPunched(_punchDirection, _punchForce);

                if(_punchForce != _defaultPunchForce) {
                    _punchForce = _defaultPunchForce;
                    if(_isPlayer1) GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "none");
                    else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "none");
                }
            }

            //No one was hit
            else {
                // animacao
                if (_punchForce != _defaultPunchForce)
                {
                    _punchForce = _defaultPunchForce;
                    if(_isPlayer1) GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "none");
                    else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "none");
                    _anim.SetTrigger("PunchBaseball");
                    _anim.SetBool("Baseball", false);
                }
                else _anim.SetTrigger("Punch");
            }
        }
    }

    public void GetPunched(int direction, float punchForce) {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        _rb.AddForce(Vector2.right * punchForce * direction, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
        SomSoco.Play();
    }

    public void EnableBaseballBat(float newForce) {
        _anim.SetBool("Baseball", true);
        _punchForce = newForce;
    }

    public void CancelBaseballBat() {
        _anim.SetBool("Baseball", false);
        _punchForce = _defaultPunchForce;
    }

    private void DelayToMovePlayer(GameObject target, float delay) {
        target.GetComponent<Rigidbody2D>().velocity = new Vector2(0, target.GetComponent<Rigidbody2D>().velocity.y);
        target.GetComponent<PlayerMovement>().Stun(delay);
        // target.GetComponent<PlayerMovement>()._canMove = false;
        // target.GetComponent<Animator>().SetBool("Stun", true);

        // yield return new WaitForSeconds(delay);

        // target.GetComponent<Animator>().SetBool("Stun", false);
        // target.GetComponent<PlayerMovement>()._canMove = true;
    }

    private void DelayToMoveMob(GameObject target, float delay) {
        target.GetComponent<Rigidbody2D>().velocity = new Vector2(0, target.GetComponent<Rigidbody2D>().velocity.y);
        target.GetComponent<GroundMobsMovement>().Stun(delay);
        // target.GetComponent<GroundMobsMovement>()._canMove = false;

        // yield return new WaitForSeconds(delay);

        // target.GetComponent<GroundMobsMovement>()._canMove = true;
    }
}