using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaw2Players : MonoBehaviour
{
    [SerializeField] RuntimeAnimatorController anim_Nick;
    [SerializeField] RuntimeAnimatorController anim_Jeff;
    // Add more Animator Controllers as needed

    [SerializeField] Animator player1;
    [SerializeField] Animator player2;

    void Start()
    {
        string selectedCharacterPlayer1 = PlayerPrefs.GetString("SelectedCharacterPlayer1", "");
        string selectedCharacterPlayer2 = PlayerPrefs.GetString("SelectedCharacterPlayer2", "");

        // Check and assign the Animator Controllers based on the selected characters
        if (selectedCharacterPlayer1 == "Nick")
        {
            player1.runtimeAnimatorController = anim_Nick;
        }
        // Add more conditions for other characters and players

        if (selectedCharacterPlayer2 == "Jeff")
        {
            player2.runtimeAnimatorController = anim_Jeff;
        }
        // Add more conditions for other characters and players
    }
}
