using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_LoadSetUp : MonoBehaviour
{
    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "SS_Terrain")
        {
            yield return new WaitForSeconds(.05f);
            gameObject.GetComponent<Collider2D>().enabled = false;
            SetPosition();
        }
    }
    void SetPosition()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        
        GameObject.Find("P_MonitorReadyState").SendMessage("Player2_Ready");
    }
}
