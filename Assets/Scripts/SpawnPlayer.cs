using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController anim_Jeff;
    [SerializeField] RuntimeAnimatorController anim_Nick;
    [SerializeField] RuntimeAnimatorController anim_Poli;
    [SerializeField] RuntimeAnimatorController anim_Tim;
    
    [SerializeField] Animator player1;
    // Start is called before the first frame update
    void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "");

        if (selectedCharacter == "Jeff") player1.runtimeAnimatorController = anim_Jeff;
        if (selectedCharacter == "Nick") player1.runtimeAnimatorController = anim_Nick;
        if (selectedCharacter == "Poli") player1.runtimeAnimatorController = anim_Poli;
        if (selectedCharacter == "Tim") player1.runtimeAnimatorController = anim_Tim;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
