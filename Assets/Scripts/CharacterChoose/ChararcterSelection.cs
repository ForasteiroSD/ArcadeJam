using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ChararcterSelection : MonoBehaviour
{
    public Button[] characterButtons; // Assign in the Inspector
    public SpriteRenderer[] charactersRenderer; // Assign in the Inspector
    private List<GameObject> selectedObjects = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < charactersRenderer.Length; i++) {
            if(charactersRenderer[i] != null) charactersRenderer[i].enabled = false;
            else Debug.LogError("Please assign the" + i + "° character Sprite Render and ensure they have SpriteRenderer components.");
        }
    }

    private void Update()
    {
        // Check if a UI element is currently selected
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        if (selectedObject != null)
        {
            // Check if the object is not already in the list
            if (!selectedObjects.Contains(selectedObject))
            {
                // Add the selected object to the list
                selectedObjects.Add(selectedObject);

                // Perform actions or handle the selection as needed
                Debug.Log("Object selected: " + selectedObject.name);
            }   
        

            Debug.Log(EventSystem.current.currentSelectedGameObject);
            // Check if a button is currently selected
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                for(int i = 0; i < characterButtons.Length; i++) {
                    if (selectedObjects.Contains(characterButtons[i].gameObject)) {
                        // Activate the SpriteRenderer for the character when the button is selected
                        charactersRenderer[i].enabled = true;
                    } else {
                        // Deactivate the SpriteRenderer for the character
                        charactersRenderer[i].enabled = false;
                    }
                }
            }
            selectedObjects.Clear();
        }
    }
}
