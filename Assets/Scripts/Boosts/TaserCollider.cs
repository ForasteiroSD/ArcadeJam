using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CancelBoosts.CancelAllBoosts(collision.gameObject);
            collision.gameObject.GetComponent<Taser>().enabled = true;
            if (collision.gameObject.name == "Player1") GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "taser");
            else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "taser");
            Destroy(gameObject);
        }
    }
}
