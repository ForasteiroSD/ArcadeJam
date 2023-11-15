using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolhePlayer : MonoBehaviour
{
   [SerializeField] GameObject[] players; 
   [SerializeField] GameObject SceneChoose;   
   [SerializeField] GameObject HUD;

    private int currentPlayerIndex = 0; 
    private void Start()
    {
        
        SetPlayerActive(currentPlayerIndex);
    }

    public void UpButton()
    {
        
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;

        SetPlayerActive(currentPlayerIndex);
    }

    public void DownButton()
    {
        currentPlayerIndex = (currentPlayerIndex - 1) % players.Length;

        SetPlayerActive(currentPlayerIndex);
    }

    public void comeca()
    {
        Camera.main.GetComponent<CameraFollowPlayer>()._currentTime = 0f;
        SceneChoose.SetActive(false);
        HUD.SetActive(true);
    }

    private void SetPlayerActive(int playerIndex)
    {
        
        foreach (GameObject player in players)
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
        }

        
        players[playerIndex].GetComponent<SpriteRenderer>().enabled = true;
    }

}
