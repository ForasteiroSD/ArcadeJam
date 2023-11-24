using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ChararcterSelection : MonoBehaviour
{
    public Button characterButton1; // Assign in the Inspector
    public Button characterButton2; // Assign in the Inspector

    public GameObject character1; // Assign in the Inspector
    public GameObject character2; // Assign in the Inspector

    private SpriteRenderer character1Renderer;
    private SpriteRenderer character2Renderer;
    private List<GameObject> selectedObjects = new List<GameObject>();

    private void Start()
    {
        character1Renderer = character1.GetComponent<SpriteRenderer>();
        character2Renderer = character2.GetComponent<SpriteRenderer>();

        // Ensure that the associated GameObjects and SpriteRenderers are not null
        if (character1 != null && character2 != null && character1Renderer != null && character2Renderer != null)
        {
            // Deactivate the SpriteRenderers initially
            character1Renderer.enabled = true;
            character2Renderer.enabled = false;
        }
        else
        {
            Debug.LogError("Please assign the character GameObjects and ensure they have SpriteRenderer components.");
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
                if (selectedObjects.Contains(characterButton1.gameObject))
                {
                    // Activate the SpriteRenderer for character 1 when the button is selected
                    character1Renderer.enabled = true;

                    // Deactivate the SpriteRenderer for character 2
                    character2Renderer.enabled = false;
                }
                else if (selectedObjects.Contains(characterButton2.gameObject))
                {
                    // Activate the SpriteRenderer for character 2 when the button is selected
                    character2Renderer.enabled = true;

                    // Deactivate the SpriteRenderer for character 1
                    character1Renderer.enabled = false;
                }
            }
            selectedObjects.Clear();
        }
    }
}
