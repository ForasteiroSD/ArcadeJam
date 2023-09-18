using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunController : MonoBehaviour
{
    private float _timeStun;
    private float _timeElapsed;
    private bool stun;
    private GameObject _gameObject;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player") _anim = gameObject.GetComponent<Animator>();
        _timeElapsed = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (stun)
        {
            _timeElapsed += Time.deltaTime;
            if (_gameObject.name == "Player1" || _gameObject.name == "Player2") 
            { 
                _gameObject.GetComponent<PlayerMovement>().enabled = false;
                _anim.SetBool("Stun", true);
            }
            else _gameObject.GetComponent<GroundMobsMovement>().enabled = false;

            if (_timeElapsed > _timeStun)
            {
                // estou stuando e o tempo e maior que o para acabar o stun
                if (_gameObject.name == "Player1" || _gameObject.name == "Player2")
                {
                    _anim.SetBool("Stun", false);
                    _gameObject.GetComponent<PlayerMovement>().enabled = true;
                }
                else _gameObject.GetComponent<GroundMobsMovement>().enabled = true;
                stun = false;
            }
        }
        else
        {
            _timeElapsed = 0;
        }
    }

    public void Stun(GameObject obj, float _time)
    {
        Debug.Log("stunado");
        Debug.Log(obj.name);
        stun = true;
        _gameObject = obj;
        _timeStun = _time;
    }

}
