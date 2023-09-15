using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMobGround : MonoBehaviour {
    private GroundMobsMovement _mob;
    private void Start() {
        _mob = this.transform.parent.gameObject.GetComponent<GroundMobsMovement>();
    }

    public void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "Ground") _mob.ChangeDirection();
    }
}