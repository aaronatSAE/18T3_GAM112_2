using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePig : MonoBehaviour {

    public Transform[] points;
    public float speed = 2f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool movingLeft = false;
    private bool eating = false;

    private void Start()
    {
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

                print("moving right");
            }
            else
            {
                rb.velocity = Vector2.left * speed * Time.deltaTime;

                print("moving left");
            }
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Start")
        {
            
            movingLeft = false;
            anim.SetBool("movingLeft", false);
            rb.velocity = Vector2.zero;
        }
        else if(other.gameObject.tag == "End")
        {
            
            movingLeft = true;
            anim.SetBool("movingLeft", true);
            rb.velocity = Vector2.zero;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "CarrotThrow")
        {
            eating = true;
            rb.velocity = Vector2.zero;
            Destroy(other.gameObject);
            if (eating)
            {
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
    }

}
