using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsMovement : MonoBehaviour {
    [SerializeField] private Camera _cam;
    [SerializeField] private float _velocity = 1f;

    private void Start() {
        _cam = Camera.main;
    }

    private void Update() {
        transform.position = new Vector3(transform.position.x, transform.position.y + (_velocity * Time.deltaTime), transform.position.z);

        if(!ICanSee(this.gameObject)) Destroy(this.gameObject);
    }

    private bool ICanSee(GameObject Object) {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_cam);
        if (GeometryUtility.TestPlanesAABB(planes, Object.GetComponent<Collider2D>().bounds)) return true;
        else return false;
    }
}