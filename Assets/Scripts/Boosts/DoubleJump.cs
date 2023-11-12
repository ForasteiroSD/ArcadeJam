using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DoubleJump : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player") {
            CancelBoosts.CancelAllBoosts(collider.gameObject);
            collider.gameObject.GetComponent<PlayerMovement>().EnableDoubleJump();

            if(collider.gameObject.name == "Player1") GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "boot");
            else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "boot");
            Destroy(this.gameObject);
        }
    }
}