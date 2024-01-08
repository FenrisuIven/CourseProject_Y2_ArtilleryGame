using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Proj : MonoBehaviour {
    #region Variables
    public float power = 0.1f;
    Rigidbody2D rb;
    LineRenderer lr;
    Vector3 startPos;

    bool firstTouch = true;

    AudioSource firing;
    AudioSource thud;

    Player player1;
    Player player2;
    #endregion
    
    private void Start() {
        GetComponent<Renderer>().enabled = false;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        startPos = rb.transform.position;

        InitializeAudioFiles();
        player1 = GameObject.Find("Player 1").GetComponent<Player>();
        player2 = GameObject.Find("Player 2").GetComponent<Player>();
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0) && firstTouch) lr.SetPosition(0, rb.transform.position);

        if (Input.GetMouseButton(0) && firstTouch) {
            lr.enabled = true;
            Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (CircleEq(endPos.x - startPos.x, endPos.y - startPos.y) > 1.5f) {
                Ray2D ray = new Ray2D(startPos, ((Vector3)endPos - startPos));
                endPos = ray.GetPoint(1.2f);
            }
            lr.SetPosition(1, endPos);
        }

        if (Input.GetMouseButtonUp(0) && firstTouch) {
            firing.Play();
            
            GetComponent<Renderer>().enabled = true;
            Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (CircleEq(endPos.x - startPos.x, endPos.y - startPos.y) > 1.5f) {
                Ray2D ray = new Ray2D(startPos, (Vector3)endPos - startPos);
                endPos = ray.GetPoint(1.2f);
            }
            
            Vector2 _velocity = ((Vector3)endPos - startPos) * power;
            _velocity.x *= 2f;
            _velocity.y *= 2f;
            
            lr.enabled = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = _velocity;

            firstTouch = false;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "SS_Terrain") {
            rb.bodyType = RigidbodyType2D.Static;
            rb.gameObject.GetComponent<Collider2D>().enabled = false;
            thud.Play();
            CheckForPlayer();
            GameObject.Find("PlayersControllers").GetComponent<TurnController>().Attack();
            yield return new WaitForSeconds(2);
        }
    }

    void CheckForPlayer() {
        GameObject.Find("Player 1").GetComponent<Collider2D>().enabled = true;
        GameObject.Find("Player 2").GetComponent<Collider2D>().enabled = true;
        
        Vector3 origin = transform.position;
        Collider2D hit = Physics2D.OverlapCircle(new Vector2(origin.x,origin.y), 1);
        Debug.DrawRay(origin, new Vector2(0, 1));
        if (hit) {
            Debug.Log(hit.gameObject.name);
            if (hit.gameObject.name == "Player 1") player1.ReceiveDamage(10);
            else if (hit.gameObject.name == "Player 2") player2.ReceiveDamage(10);
        }
        Destroy(gameObject);
        
        GameObject.Find("Player 1").GetComponent<Collider2D>().enabled = false;
        GameObject.Find("Player 2").GetComponent<Collider2D>().enabled = false;
    }

    float CircleEq(float x, float y) => x * x + y * y;
    
    private void InitializeAudioFiles() {
        firing = GameObject.Find("Firing").GetComponent<AudioSource>();
        thud = GameObject.Find("Thud").GetComponent<AudioSource>();
    }
}
