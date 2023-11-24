using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBat : MonoBehaviour {
    [SerializeField] private float _newPunchForce;

    // private void OnTriggerEnter2D(Collider2D collider) {
    //     if(collider.tag == "Player") {
    //         CancelBoosts.CancelAllBoosts(collider.gameObject);
    //         collider.gameObject.GetComponent<Punch>().EnableBaseballBat(_newPunchForce);

    //         if(collider.gameObject.name == "Player1") GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "baseballBatt");
    //         else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "baseballBatt");
            
    //         Destroy(this.gameObject);
    //     }
    // }
    public void Baseball_Bat(Collider2D collider) {
        if(collider.tag == "Player") {
            CancelBoosts.CancelAllBoosts(collider.gameObject);
            collider.gameObject.GetComponent<Punch>().EnableBaseballBat(_newPunchForce);

            if(collider.gameObject.name == "Player1") GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "baseballBatt");
            else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "baseballBatt");
            
           
        }
    }
}
