using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D rb;
    private GameObject playerStats;

    public Transform carrotSprite;
    public float speed;
    public float power;
    public float rotateSpeed = 200f;

    private float carrotRotSpeed = 135f;
    private bool leverHit;

    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = GameObject.FindGameObjectWithTag("ScriptManager");

        // shoot forward on spawn
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * power);

    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)player.transform.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        // when lever is hit, return to player
        if (leverHit)
        {
            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;

            carrotSprite.Rotate(new Vector3(0f, 0f, 1f * carrotRotSpeed));

            

            // when carrot returnds to player, destroy carrot
            if (transform.position.x  < (player.transform.position.x + 1.2f))
            {
                
                Destroy(gameObject);
            }
        }
        

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Lever")
        {
            coll.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            coll.gameObject.SendMessage("ActivateLever");
            leverHit = !leverHit;
            playerStats.GetComponent<PlayerStats>().score += 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if(coll.gameObject.tag == "Barrel")
        {
            coll.gameObject.GetComponent<Barrel>().carrotHit = true;
            Destroy(gameObject);
        }
        //else if(coll.gameObject.tag != "Pig")
        //{
        //    Destroy(gameObject);
        //}

    }
}
