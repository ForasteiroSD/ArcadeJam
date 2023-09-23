using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStun : MonoBehaviour {
    public void GetStuned(int direction, float punchForce, float time) {
        if(this.gameObject.tag == "Player") {
            this.GetComponent<Punch>().GetPunched(direction, punchForce);
            this.GetComponent<PlayerMovement>().Stun(time);

            // StartCoroutine(CancelStun(0, time));
        }
        // else if (this.gameObject.tag == "Enemy") {
        //     this.GetComponent<GroundMobsMovement>().GetPunched(direction, punchForce);
        //     this.GetComponent<GroundMobsMovement>()._canMove = false;

        //     StartCoroutine(CancelStun(1, time));
        // }
    }

    // IEnumerator CancelStun(int target, float time) {
    //     yield return new WaitForSeconds(time);

    //     if(target == 0) {
    //         this.GetComponent<PlayerMovement>()._canMove = true;
    //         this.GetComponent<PlayerMovement>()._canJump = true;
    //     }
    //     else if(target == 1) this.GetComponent<GroundMobsMovement>()._canMove = true;
    // }
}
