using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilFire : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform aim;
    [SerializeField] bool _isPlayer1;
    // Start is called before the first frame update
    [SerializeField] bool _canShoot;
    [SerializeField] AudioSource _somLancando;

    public void enableFire()
    {
        if(this.gameObject.name == "Player1") GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "missil");
            else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "missil");
        _canShoot = true;
    }

    public void desableFire()
    {
        _canShoot = false;
    }

    void Update()
    {
        if (_canShoot)
        {
            // CancelBoosts.CancelAllBoosts(gameObject);
            if (((_isPlayer1 && Input.GetKeyDown(KeyCode.Space)) || (!_isPlayer1 && Input.GetKeyDown(KeyCode.Return))))
            {
                Fire();
            }   
        }

    }

    public void Fire()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 0.33f, 0);
        GameObject instantiatedPrefab = Instantiate(projectile, spawnPosition, Quaternion.identity);
        MIssil prefabScript = instantiatedPrefab.GetComponent<MIssil>();

        _somLancando = GameObject.Find("SomLancando").GetComponent<AudioSource>();
        _somLancando.Play();

        // Set variables or call methods on the script
        if (prefabScript != null)
        {
            if (aim.position.y + 2 >= gameObject.transform.position.y)
            {
                Debug.Log("If 1");
                prefabScript.SetTarget(aim); // Set an initial value
                prefabScript.SetPlayerShotting(gameObject);
            }
            else
            {
                Debug.Log("If 2");
                prefabScript.SetTarget(gameObject.transform); // Set an initial value
                prefabScript.SetPlayerShotting(aim.GetComponent<GameObject>());
            }
        }
        _canShoot = false;

        if(_isPlayer1) GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "none");
        else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "none");
    }

}
