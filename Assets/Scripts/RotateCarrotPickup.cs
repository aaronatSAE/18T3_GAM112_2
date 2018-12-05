using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCarrotPickup : MonoBehaviour {


    private float rotateY;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateY += 3f;
        transform.eulerAngles = new Vector3(0f, rotateY, -45f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        
    }




}
