using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelectedP1 : MonoBehaviour, ISelectHandler {
    public void OnSelect(BaseEventData data) {
        GameObject[] _buttons = GameObject.Find("SelectedButtons").GetComponent<CurrentSelectedButtons>().currentSelectedButtons;
        _buttons[0] = this.gameObject;
        Debug.Log(this.gameObject.name);
    }
}