using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunPlayer : MonoBehaviour {
    [SerializeField] private float _punchForce = 1f;
    [SerializeField] private float _stunDuration = 1.5f;
    [SerializeField] private float _timeToStun = 1.5f;
    private float _nextStunTime = 0;
    private int _direction = 0;

    // private void Update() {
    //     Debug.DrawRay(transform.position, Vector3.right * _direction * _changeDirectionRange, Color.green);
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * _direction, _changeDirectionRange);

    //     if(hit.collider != null && hit.collider.gameObject.tag == "Ground") ChangeDirection();
    // }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player" && Time.time >= _nextStunTime) {
            Vector3 direction = collider.transform.position - transform.position;
            if(direction[0] > 0) _direction = 1;
            if(direction[0] < 0) _direction = -1;
            collider.GetComponent<GetStun>().GetStuned(_direction, _punchForce, _stunDuration);
            _nextStunTime = Time.time + _timeToStun;
        }
    }
}
