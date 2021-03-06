﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePig : MonoBehaviour {

    public Transform[] points;
    public float speed = 2f;
    public float hitAmount;
    private Rigidbody2D rb;
    private Animator anim;
    private bool movingLeft = false;
    private bool eating = false;
    private PlayerStats hpScript;
    private bool jumpedOn = false;


   

    private void Start()
    {
        hpScript = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (!eating)
        {
            
                if (!movingLeft)
                {
                    rb.velocity = Vector2.right * speed * Time.deltaTime;
                    anim.SetBool("movingLeft", false);
                    
                }
                else
                {
                    rb.velocity = Vector2.left * speed * Time.deltaTime;
                    anim.SetBool("movingLeft", true);
                    
                }
            
            
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Start")
        {
            
            movingLeft = false;
            rb.velocity = Vector2.zero;
        }
        else if(other.gameObject.tag == "End")
        {
            
            movingLeft = true;
            rb.velocity = Vector2.zero;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "CarrotThrow")
        {
            eating = true;
            rb.velocity = Vector2.zero;
            Destroy(coll.gameObject);
            if (eating)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(GetComponent<Rigidbody2D>());

                if (movingLeft)
                {
                    anim.SetBool("idleLeft", true);
                }
                else if (!movingLeft)
                {
                    anim.SetBool("idleRight", true);
                }
            }



        }

        else if (coll.gameObject.tag == "Player")
        {
            Rigidbody2D rbPlayer = coll.gameObject.GetComponent<Rigidbody2D>();

            
            if (coll.contacts[0].normal.y < 0f)
            {
                eating = true;
                rb.velocity = Vector2.zero;
                GetComponent<BoxCollider2D>().enabled = false;
                //Jump();
                Debug.Log("hit top ");
            }
            else
            {
                coll.gameObject.SendMessage("TakeHit");
                rbPlayer.AddForce(-transform.right * hitAmount);
                hpScript.life -= 1;
                Debug.Log("hit left ");
            }
        }


    }
}
