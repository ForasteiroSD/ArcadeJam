using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [SerializeField] private CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_player1.transform.position.y > _player2.transform.position.y)
        {
            vcam.Follow = _player1.transform;
        }
        else
        {
            vcam.Follow = _player2.transform;
        }
    }
}
