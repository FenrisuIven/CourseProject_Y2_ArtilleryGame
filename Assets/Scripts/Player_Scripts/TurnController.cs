using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public enum TurnState { PLAYER1_TURN, PLAYER2_TURN}

public class TurnController : MonoBehaviour
{
    static TurnState state;

    public GameObject projectile;
    
    public GameObject player1_obj;
    public GameObject player2_obj;
    
    GameObject player1_Proj;
    GameObject player2_Proj;

    public GameObject endScreen;
    public GameObject rotationController;
//=----------------------------------------------------------------------------------------------------------------
    private void StartScript() { StartCoroutine(SetupTurn()); }
    
    IEnumerator SetupTurn()
    {
        yield return new WaitForSeconds(2f);
        state = TurnState.PLAYER1_TURN;
        Player1Turn();
    }
//=---------------------------------------------------------------------------------------------------------------
    void Player1Turn()
    {
        Instantiate(projectile, player1_obj.transform, worldPositionStays: false);
    }
    void Player2Turn()
    {
        Instantiate(projectile, player2_obj.transform, worldPositionStays: false);
    }
//=----------------------------------------------------------------------------------------------------------------
    public void Attack()
    {
        if (player1_obj.GetComponent<Player>().dead || player2_obj.GetComponent<Player>().dead)
        {
            gameObject.SetActive(false);
            if (player1_obj.GetComponent<Player>().dead)
            {
                endScreen.GetComponent<EndScreen>().playerName = "Player 1";
            }
            else if (player2_obj.GetComponent<Player>().dead)
            {
                endScreen.GetComponent<EndScreen>().playerName = "Player 2";
            }
            endScreen.SetActive(true);
            return; 
        }
        
        if (state == TurnState.PLAYER1_TURN)
        {
            state = TurnState.PLAYER2_TURN;
            Player2Turn();
        }
        else if (state == TurnState.PLAYER2_TURN)
        {
            state = TurnState.PLAYER1_TURN;
            Player1Turn();
        }
    }
//=----------------------------------------------------------------------------------------------------------------
}
