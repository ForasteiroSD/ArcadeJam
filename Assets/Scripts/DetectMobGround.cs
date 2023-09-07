using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMobGround : MonoBehaviour {
    private MobsMovement _mob;

    private void Start() {
        _mob = this.transform.parent.gameObject.GetComponent<MobsMovement>();
    }

    public void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "Ground") _mob.ChangeDirection();
    }
}