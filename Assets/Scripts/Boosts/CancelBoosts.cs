using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CancelBoosts {
    public static void CancelAllBoosts(GameObject player) {
        player.GetComponent<PlayerMovement>().CancelAdrenaline();
        player.GetComponent<PlayerMovement>().CancelDoubleJump();
        player.GetComponent<Punch>().CancelBaseballBat();
    }
}