using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _canva;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _canva.SetActive(true);
    }
}
