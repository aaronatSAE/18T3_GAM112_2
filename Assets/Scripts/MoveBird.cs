using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBird : MonoBehaviour {

    public GameObject apple;
    public Transform spawnPoint;
    private Rigidbody2D rb;
    public float speed;

	// Use this for initialization
	void Awake ()
    {
        
        rb = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
        InvokeRepeating("SpawnApple", 4f, 4f);
    }
    // Update is called once per frame
    void Update () {
        rb.velocity = Vector2.left * speed * Time.deltaTime;
	}

    private void SpawnApple()
    {
        Instantiate(apple, spawnPoint.position, spawnPoint.rotation);
    }
}
