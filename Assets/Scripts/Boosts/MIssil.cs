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

    public GameObject PlayerShotting;
    private Vector3 direction;
  
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (target != null)
        {
            
            direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            
            Debug.Log(direction);   
            rb.MovePosition((Vector2)transform.position + ((Vector2) direction * speed * Time.deltaTime));
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
        if(collider.tag == "Player" && collider.gameObject != PlayerShotting) {
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
