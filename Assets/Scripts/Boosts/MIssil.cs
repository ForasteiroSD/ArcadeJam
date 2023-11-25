using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIssil : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 5f;
    [SerializeField] float _timeStun = 5f;
    [SerializeField] float _forceExplosion;
    private Rigidbody2D rb;
    public Vector2 direction;
    public GameObject PlayerShotting;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

        // if (direction.y < 0)
        // {  
        //     PlayerShotting.GetComponent<PlayerMovement>().GetPunched(-direction.y, _forceExplosion);
        //     Destroy(this.gameObject);
        // }

    }
    public void SetPlayerShotting(GameObject _PlayerShotting)
    {
        PlayerShotting = _PlayerShotting;
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player") {
            collider.gameObject.GetComponent<StunController>().Stun(collider.gameObject, _timeStun);
            collider.GetComponent<PlayerMovement>().GetPunched(direction.y, _forceExplosion);
            Destroy(this.gameObject);
            
        }
        else if (collider.name != "CameraLimit")
        {
            Debug.Log("f");
            Destroy(this.gameObject);

        }
    }
}
