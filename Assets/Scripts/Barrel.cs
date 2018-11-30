using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour {

    public GameObject carrots;
    public Transform[] spawnPoints;
    public GameObject anim;
    public Transform spawn;
    public SpriteRenderer myBarrel;
    public float speed = 1f;
    public float hitAmount = 1000f;
    public float force = 10f;
    private float timer = 0f;

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
        timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (!carrotHit)
        {
            barrelRB.velocity = Vector2.left * speed;
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
                for(int i = 0; i< spawnPoints.Length; ++i)
                {
                    timer = 0;
                    float z = Random.Range(spawnPoints[i].rotation.z - 2f, spawnPoints[i].rotation.z + 2f);
                    Quaternion newRot = new Quaternion(0f, 0f, z, 0f);
                    GameObject newCarrot = Instantiate(carrots, spawnPoints[i].position, newRot);
                    newCarrot.GetComponent<CircleCollider2D>().enabled = false;
                    StartCoroutine(ColliderOnOff(newCarrot));

                    Rigidbody2D rbTwo = newCarrot.GetComponent<Rigidbody2D>();
                    rbTwo.AddForce(spawnPoints[i].up * force);
                }
                Destroy(newAnim, 2.5f);
                myBarrel.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                //Jump();
                Debug.Log("hit top ");
            }

        }
    }

    IEnumerator ColliderOnOff(GameObject carrot)
    {
        carrot.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        print("testing coroutine");
        carrot.GetComponent<CircleCollider2D>().enabled = true;
        Destroy(gameObject);
        yield return new WaitForSeconds(1);
    }
}
