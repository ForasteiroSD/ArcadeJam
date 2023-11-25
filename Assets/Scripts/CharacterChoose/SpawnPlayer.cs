using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {
    [SerializeField] private RuntimeAnimatorController anim_Jeff;
    [SerializeField] private RuntimeAnimatorController anim_Nick;
    [SerializeField] private RuntimeAnimatorController anim_Poli;
    [SerializeField] private RuntimeAnimatorController anim_Tim;

    [SerializeField] private Animator player1;
    [SerializeField] private Animator player2;
    [SerializeField] private bool _isSinglePlayer;
    // Start is called before the first frame update
    void Start() {
        if(_isSinglePlayer) {
            string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "");

            if (selectedCharacter == "Jeff") player1.runtimeAnimatorController = anim_Jeff;
            else if (selectedCharacter == "Nick") player1.runtimeAnimatorController = anim_Nick;
            else if (selectedCharacter == "Poli") player1.runtimeAnimatorController = anim_Poli;
            else if (selectedCharacter == "Tim") player1.runtimeAnimatorController = anim_Tim;
        }
        
        else {
            string selectedCharacter1 = PlayerPrefs.GetString("SelectedCharacterPlayer1", "");
            string selectedCharacter2 = PlayerPrefs.GetString("SelectedCharacterPlayer2", "");

            if (selectedCharacter1 == "Jeff") player1.runtimeAnimatorController = anim_Jeff;
            else if (selectedCharacter1 == "Nick") player1.runtimeAnimatorController = anim_Nick;
            else if (selectedCharacter1 == "Poli") player1.runtimeAnimatorController = anim_Poli;
            else if (selectedCharacter1 == "Tim") player1.runtimeAnimatorController = anim_Tim;

            if (selectedCharacter2 == "Jeff") player2.runtimeAnimatorController = anim_Jeff;
            else if (selectedCharacter2 == "Nick") player2.runtimeAnimatorController = anim_Nick;
            else if (selectedCharacter2 == "Poli") player2.runtimeAnimatorController = anim_Poli;
            else if (selectedCharacter2 == "Tim") player2.runtimeAnimatorController = anim_Tim;
        }
    }
}