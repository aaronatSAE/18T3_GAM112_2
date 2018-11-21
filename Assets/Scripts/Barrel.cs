using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour {

    public GameObject anim;
    public Transform spawn;
    public float speed;
    public float hitAmount = 1000f;

    //if hit by carrot, stop rolling
    public bool carrotHit = false;

    private PlayerStats hpScript;
    private Rigidbody2D barrelRB;

    private void Awake()
    {
        hpScript = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<PlayerStats>();
    }

    private void Start()
    {
        barrelRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        speed += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (!carrotHit)
        {
            barrelRB.AddForce(-transform.right * speed);
        }
        else
        {
            barrelRB.velocity = Vector3.zero;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D coll)

    {
        

        if (coll.gameObject.tag == "Player")
        {
            Rigidbody2D rb = coll.gameObject.GetComponent<Rigidbody2D>();

            if (coll.contacts[0].normal.x > 0f)
            {
                rb.AddForce(-transform.right * hitAmount);
                hpScript.life -= 1;
                Debug.Log("hit left ");
            }
            else if (coll.contacts[0].normal.y < 0f)
            {
                GameObject newAnim = Instantiate(anim, spawn.position, Quaternion.identity) as GameObject;
                Destroy(newAnim, 2.5f);
                Destroy(gameObject);
                //Jump();
                Debug.Log("hit top ");
            }

        }
    }
}
