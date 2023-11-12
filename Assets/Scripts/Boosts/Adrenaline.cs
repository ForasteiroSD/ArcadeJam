using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adrenaline : MonoBehaviour {
    public AudioSource SomAdrenalina;
    [SerializeField] private float _duration;
    [SerializeField] private float _speedMultiplier;
    private void Start () {
        SomAdrenalina = GameObject.Find("AdrenalinaSom").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player") {
            CancelBoosts.CancelAllBoosts(collider.gameObject);
            collider.gameObject.GetComponent<PlayerMovement>().Adrenaline(_duration, _speedMultiplier);
            

            if(collider.gameObject.name == "Player1") GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "adrenaline");
            else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "adrenaline");
            SomAdrenalina.Play();
            Destroy(this.gameObject);
        }
    }
}