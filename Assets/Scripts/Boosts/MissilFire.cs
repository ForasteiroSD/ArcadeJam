using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilFire : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform aim;
    [SerializeField] bool _isPlayer1;
    // Start is called before the first frame update
    private bool _canShoot;

    public void enableFire()
    {
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
            CancelBoosts.CancelAllBoosts(gameObject);
            if (((_isPlayer1 && Input.GetKeyDown(KeyCode.Space)) || (!_isPlayer1 && Input.GetKeyDown(KeyCode.Return))))
            {
                Fire();
            }   
        }

    }

    public void Fire()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 1, 0);
        GameObject instantiatedPrefab = Instantiate(projectile, spawnPosition, Quaternion.identity);
        MIssil prefabScript = instantiatedPrefab.GetComponent<MIssil>();

        // Set variables or call methods on the script
        if (prefabScript != null)
        {
            prefabScript.SetTarget(aim); // Set an initial value
            prefabScript.SetPlayerShotting(gameObject);
        }
        _canShoot = false;
    }

}
