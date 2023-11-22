using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour {
    private int _maxNameSize = 4;
    public static string playerName = "";
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _warning;

    public void UpdatePlayerName(string newChar) {
        //Delete
        if(newChar == "delete") playerName = playerName.Substring(0, playerName.Length-1);
        else if(newChar == "aceitar") Debug.Log("pronto");
        else if(playerName.Length < _maxNameSize) playerName = string.Concat(playerName, newChar);
        else StartCoroutine(MaxSizeReached(2f));
        _text.SetText(playerName);
    }

    private IEnumerator MaxSizeReached(float time) {
        _warning.SetText("O tamanho máximo foi atingido!");
        yield return new WaitForSeconds(time);
        _warning.SetText("");
    }
}
