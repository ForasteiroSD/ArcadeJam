using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController anim_Nick;
    
    [SerializeField] Animator player1;
    // Start is called before the first frame update
    void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "");

        if (selectedCharacter == "Nick")
        {
            player1.runtimeAnimatorController = anim_Nick;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
