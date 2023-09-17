using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRight : MonoBehaviour
{
    [SerializeField] private GameObject otherTeleport;
    [SerializeField] private float teleportRange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(otherTeleport.transform.position.x + teleportRange, collision.transform.position.y, otherTeleport.transform.position.z);
    }
}
