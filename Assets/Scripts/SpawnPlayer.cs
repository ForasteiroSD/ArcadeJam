using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject Nick;
    [SerializeField] GameObject Jeff;
    // Start is called before the first frame update
    void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "");

        if (selectedCharacter == "Jeff")
        {
            Jeff.SetActive(true);
            Nick.SetActive(false);
        }
        else if (selectedCharacter == "Nick")
        {
            Jeff.SetActive(false);
            Nick.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
