using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {

    private Rigidbody2D rb;
    public float power;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * power);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
