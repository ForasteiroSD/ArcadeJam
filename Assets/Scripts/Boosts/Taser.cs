using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taser : MonoBehaviour
{
    [SerializeField] private float _delayToPunch = 2f;
    [SerializeField] private float _punchForce = 1f;
    [SerializeField] private float _punchRange = 1f;
    [SerializeField] private float _timeStun;
    private Ray _ray;
    private bool _isPlayer1;
    private bool _canPunch = true;
    private float _lastPunchTime = 0f;
    private int _punchDirection = 1;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (this.GetComponent<PlayerMovement>() != null) _isPlayer1 = this.GetComponent<PlayerMovement>().isPlayer1;
    }

    private void Update()
    {
        _punchDirection = this.GetComponent<PlayerMovement>().lookingDirection;
        Debug.DrawRay(transform.position, Vector3.right * _punchDirection * _punchRange, Color.green);
        if (Time.time - _lastPunchTime > _delayToPunch) _canPunch = true;

        if (((_isPlayer1 && Input.GetKeyDown(KeyCode.E)) || (!_isPlayer1 && Input.GetKeyDown(KeyCode.RightControl))) && _canPunch)
        {
            _canPunch = false;
            _lastPunchTime = Time.time;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * _punchDirection, _punchRange);

            if (hit.collider != null && (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Enemy"))
            {
                hit.collider.gameObject.GetComponent<Punch>().GetPunched(_punchDirection, _punchForce);
                hit.collider.gameObject.GetComponent<StunController>().Stun(hit.collider.gameObject, _timeStun);
                if (_isPlayer1) GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "none");
                else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "none");
                gameObject.GetComponent<Taser>().enabled = false;
            }
        }
    }

    public void GetPunched(int direction, float punchForce)
    {
        _rb.AddForce(Vector2.right * punchForce * direction, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.up * punchForce * 3, ForceMode2D.Impulse);
    }

    public void CancelTaser()
    {
        enabled = false;
    }
 
}
