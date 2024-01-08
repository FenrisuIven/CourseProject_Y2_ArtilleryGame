using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Load_State : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;

    bool ready_Player1 = false;
    bool ready_Player2 = false;

    void Player1_Ready() => ready_Player1 = true;
    void Player2_Ready() => ready_Player2 = true;

    private void Update()
    {
        if (ready_Player1 && ready_Player2)
        {
            loadingScreen.SetActive(false); 
            gameObject.SetActive(false);
        }
    }
}
