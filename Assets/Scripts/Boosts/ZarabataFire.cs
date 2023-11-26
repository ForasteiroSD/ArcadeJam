using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZarabataFire : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] Transform aim;
    [SerializeField] bool _isPlayer1;
    // Start is called before the first frame update
    [SerializeField] bool _canShoot;

    public void enableFire()
    {
        if(GetComponent<Collider>().gameObject.name == "Player1") GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "zarabatana");
            else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "zarabatana");
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

        // Set variables or call methods on the script
        if (prefabScript != null)
        {
            if (aim.position.y + 2 > gameObject.transform.position.y )
            {
                prefabScript.SetTarget(aim); // Set an initial value
                prefabScript.SetPlayerShotting(gameObject);
            }
            else
            {
                prefabScript.SetTarget(gameObject.transform); // Set an initial value
                prefabScript.SetPlayerShotting(aim.GetComponent<GameObject>());
            }
        }
        _canShoot = false;
        if(_isPlayer1) GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(1, "none");
        else GameObject.Find("ChangeBoostIcon").GetComponent<ChangeBoostIcon>().ChangeIcon(2, "none");
    }
}
