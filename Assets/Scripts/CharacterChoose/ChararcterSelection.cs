using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEditor;

public class ChararcterSelection : MonoBehaviour {
    public Button[] characterButtons; // Assign in the Inspector
    public SpriteRenderer[] charactersRenderer; // Assign in the Inspector
    private GameObject[] _buttons;

    private void Start() {
        _buttons = GameObject.Find("SelectedButtons").GetComponent<CurrentSelectedButtons>().currentSelectedButtons;

        for(int i = 0; i < charactersRenderer.Length; i++) {
            if(charactersRenderer[i] != null) charactersRenderer[i].enabled = false;
            else Debug.LogError("Please assign the" + i + "° character Sprite Render and ensure they have SpriteRenderer components.");
        }
    }

    private void Update() {
        // Debug.Log(Selection.objects);
        Debug.Log("Obj0: " + _buttons[0]);
        Debug.Log("Obj1: " + _buttons[1]);

        for(int i = 0; i < characterButtons.Length; i++) {
            if(_buttons[0] == characterButtons[i].gameObject || _buttons[1] == characterButtons[i].gameObject) {
                charactersRenderer[i].enabled = true;
                // Debug.Log("Botão " + i + " tá selecionado.");
            }
            else {
                charactersRenderer[i].enabled = false;
                // Debug.Log("Botão " + i + " não tá selecionado.");
            }
        }
    }
}
