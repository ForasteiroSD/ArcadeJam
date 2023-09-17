using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _Score;
    private float _currentMinutes;
    private float _currentSeconds;
    private void OnEnable()
    {
        _currentMinutes = Camera.main.GetComponent<CameraFollowPlayer>()._currentMinutes;
        _currentSeconds = Camera.main.GetComponent<CameraFollowPlayer>()._currentSeconds;   
    }
    // Update is called once per frame
    void Update()
    {
        _Score.SetText("Seu Score foi: " + _currentMinutes + ":" + _currentSeconds.ToString("00"));
    }
}
