using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBoostIcon : MonoBehaviour {
    [SerializeField] Image _boostPlayer1;
    [SerializeField] Image _boostPlayer2;
    [SerializeField] Sprite _adrenaline;
    [SerializeField] Sprite _boot;
    [SerializeField] Sprite _baseballBat;
    [SerializeField] Sprite _zarabatana;
    [SerializeField] Sprite _missil;

    public void ChangeIcon(int player, string boost) {
        Color on = Color.white;
        Color off = Color.white;
        on.a = 1f;
        off.a = 0f;

        switch(boost) {
            case "adrenaline":
                if(player == 1) _boostPlayer1.sprite = _adrenaline;
                else _boostPlayer2.sprite = _adrenaline;
                break;
            case "boot":
                if(player == 1) _boostPlayer1.sprite = _boot;
                else _boostPlayer2.sprite = _boot;
                break;
            case "baseballBatt":
                if(player == 1) _boostPlayer1.sprite = _baseballBat;
                else _boostPlayer2.sprite = _baseballBat;
                break;
            case "zarabatana":
                if(player == 1) _boostPlayer1.sprite = _zarabatana;
                else _boostPlayer2.sprite = _zarabatana;
                break;
            case "missil":
                if(player == 1) _boostPlayer1.sprite = _missil;    
                else _boostPlayer2.sprite = _missil;
                break;
        }

        if(boost == "none") {
            if(player == 1) _boostPlayer1.color = off;
            else _boostPlayer2.color = off;
        } else {
            if(player == 1) _boostPlayer1.color = on;
            else _boostPlayer2.color = on;
        }
    }
}