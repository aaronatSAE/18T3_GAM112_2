﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public PlayerStats playerStats;
    public GameObject carrot;
    public Transform spawnPoint;

    private float runSpeed = 10f;
    private bool facingRight = true;
    private float hInput;

    //Used for flipping Character Direction
    public static Vector3 theScale;

    //Jumping Stuff
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool grounded = false;
    private float groundRadius = 0.15f;
    private bool isJumping = false;
    private bool doubleJump = true;
    private float jumpForce = 7.5f;

    private bool hitTaken = false;
    private bool isThrowing = true;
    private Animator anim;


    // Use this for initialization
    void Awake()
    {
        
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("isGrounded", grounded);



        if ((grounded) && (Input.GetButtonDown("Jump")))
        {
            //anim.SetBool("isJumping", true);
            Jump(jumpForce);
            doubleJump = true;
            anim.SetBool("isGrounded", false);

        }

        else if ((Input.GetButtonDown("Jump")) && doubleJump)
        {
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, 0f);
            Jump(jumpForce);
            anim.Play("Jumping");
            doubleJump = false;
        }

    }

    void Update()
    {

        //if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround))
        //{
            
        //    grounded = true;
        //    print("asdasd");
        //    anim.SetBool("isGrounded", grounded);
        //}
        //else
        //{
        //    print("blahsls");
        //    grounded = false;
        //    anim.SetBool("isGrounded", grounded);
        //}

        //anim.SetBool("isGrounded", grounded);

        hInput = Input.GetAxisRaw("Horizontal");

        // change direction of spawn point, so carrots fire in the right direction
        if (!facingRight)
        {
            spawnPoint.rotation = new Quaternion(0, 180f, 0, 0);
        }
        else
        {
            spawnPoint.rotation = Quaternion.identity;
        }

        // slow down the rabbit soon as the button is released
        if (!Input.GetButton("Horizontal"))
        {
            hInput = 0f;
        }

        anim.SetFloat("speed", Mathf.Abs(hInput));
        //anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        GetComponent<Rigidbody2D>().velocity = new Vector2((hInput * runSpeed), GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetButtonDown("Fire1"))
        {
            if (isThrowing)
            {
                StartCoroutine(SpawnCarrot());
                isThrowing = !isThrowing;
            }
            
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isThrowing", false);
        }

        
        //Flipping direction character is facing based on players Input
        if (hInput > 0 && !facingRight)
            Flip();
        else if (hInput < 0 && facingRight)
            Flip();
    }

    // flipping direction of character
    void Flip()
    {
        facingRight = !facingRight;
        theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // spawning carrot
    private IEnumerator SpawnCarrot()
    {
        anim.SetBool("isThrowing", true);
        anim.SetTrigger("throw");

        GameObject newCarrot = Instantiate(carrot, (new Vector2(spawnPoint.position.x, spawnPoint.position.y)), spawnPoint.rotation) as GameObject;
        Destroy(newCarrot, 3f);
        yield return new WaitForSeconds(0.5f);
        isThrowing = !isThrowing;
    }

    private void OnCollisionEnter2D(Collision2D coll)

    {
        Animator anim = coll.gameObject.GetComponentInChildren<Animator>();

        if (coll.gameObject.tag == "Barrel")
        {
            if (coll.contacts[0].normal.x < 0f)
            {
                if (!hitTaken)
                {
                    hitTaken = !hitTaken;
                    StartCoroutine(TakeHit());
                    Debug.Log("hit left ");
                }
                
            }

            else if (coll.contacts[0].normal.y > 0f)
            {
                Jump((jumpForce* 1.5f));
                Debug.Log("hit top ");
            }

        }
        else if(coll.gameObject.tag == "CarrotPickup")
        {
            playerStats.score += 10f;
            Destroy(coll.gameObject);
        }
    }

    private IEnumerator TakeHit()
    {
        anim.SetBool("isHit", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isHit", false);
        hitTaken = !hitTaken;

    }

    private void Jump(float force)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, force);
    }
}
