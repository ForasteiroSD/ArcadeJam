using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _Score;
    [SerializeField] private bool _venceu;
    private float _currentMinutes;
    private float _currentSeconds;

    public void ShowScoreText() {
        _currentMinutes = Camera.main.GetComponent<CameraFollowPlayer>()._currentMinutes;
        _currentSeconds = Camera.main.GetComponent<CameraFollowPlayer>()._currentSeconds;
        _Score.SetText("Voce Venceu!! \n Seu Score foi: " + _currentMinutes + ":" + _currentSeconds.ToString("00"));
    }
}