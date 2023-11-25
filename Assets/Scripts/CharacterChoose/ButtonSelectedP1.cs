using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelectedP1 : MonoBehaviour, ISelectHandler {
    public void OnSelect(BaseEventData data) {
        CurrentSelectedButtons.currentSelectedButtons[0] = this.gameObject;
    }
}