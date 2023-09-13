using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MORTE : MonoBehaviour
{
    [SerializeField] private float _timewait;
    [SerializeField] private float _velocityY;
    private Rigidbody2D _rb;
    private float _timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        _timeElapsed = Time.deltaTime;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed > _timewait)
        {
            _rb.velocity = new Vector3(0 ,_velocityY, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1")
        {
            SceneManager.LoadScene("Player1Win");
        }
        if(collision.gameObject.name == "Player2")
        {
            SceneManager.LoadScene("Player2Win");
        }
    }
}
