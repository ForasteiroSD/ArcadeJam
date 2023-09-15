using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
    [SerializeField] private float _timeStun;
    private float _timeElapsed;
    private bool stun;

    // Start is called before the first frame update
    void Start()
    {
        _timeElapsed = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (stun)
        {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed < _timeStun)
            {
                // estou stunado e o tempo e menor que o para acabar o stun
                gameObject.GetComponent<PlayerMovement>().enabled = false;
            }

            if (_timeElapsed > _timeStun)
            {
                // estou stuando e o tempo e maior que o para acabar o stun
                stun = false;
                gameObject.GetComponent<PlayerMovement>().enabled = true;
            }
        }
        else
        {
            _timeElapsed = 0;
        }
    }

    public void Stun()
    {
        stun = true;
    }

}
