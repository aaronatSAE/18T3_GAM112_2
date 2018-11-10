using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private float runSpeed = 10f;
    //private float maxVertHSpeed = 20f;
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
    private bool doubleJump = false;
    private float jumpForce = 5f;

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
        

    }

    void Update()
    {

        hInput = Input.GetAxisRaw("Horizontal");

       

        if ((grounded) && Input.GetButtonDown("Jump"))
        {
            //anim.SetBool("isJumping", true);
            doubleJump = true;
            anim.SetBool("isGrounded", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, jumpForce);
            
        }
        else
        {
            doubleJump = false;
        }

        if ((!grounded) && Input.GetButtonDown("Jump") && doubleJump)
        {
            Debug.Log("test");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, jumpForce);
            anim.Play("Jumping");
            doubleJump = !doubleJump;
        }

        if (!Input.GetButton("Horizontal"))
        {
            hInput = 0f;
        }

        anim.SetFloat("speed", Mathf.Abs(hInput));
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        GetComponent<Rigidbody2D>().velocity = new Vector2((hInput * runSpeed), GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isThrowing", true);
            anim.SetTrigger("throw");
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isThrowing", false);
        }

        //if (Input.GetButton("Fire2"))
        //{
        //    anim.SetBool("Sprint", true);
        //    runSpeed = 14f;
        //}
        //else
        //{
        //    anim.SetBool("Sprint", false);
        //    runSpeed = 10f;
        //}

        //Flipping direction character is facing based on players Input
        if (hInput > 0 && !facingRight)
            Flip();
        else if (hInput < 0 && facingRight)
            Flip();
    }
    ////Flipping direction of character
    void Flip()
    {
        facingRight = !facingRight;
        theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

   
}
