using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonSelectedP2 : MonoBehaviour, ISelectHandler {
    public void OnSelect(BaseEventData data) {
        CurrentSelectedButtons.currentSelectedButtons[1] = this.gameObject;
    }
}