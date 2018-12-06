using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBird : MonoBehaviour {

    public GameObject apple;
    public Transform spawnPoint;
    public float speed;

    private Rigidbody2D rb;
    private float randomSpawnRate;
    private bool spawnApple = true;

	// Use this for initialization
	void Awake ()
    {
        
        rb = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
        
        //InvokeRepeating("SpawnApple", 4f, 4f);
    }
    // Update is called once per frame
    void Update () {
        randomSpawnRate = Random.Range(1f, 3f);

        if (spawnApple)
        {
            spawnApple = false;
            StartCoroutine(SpawnApple());
        }

        rb.velocity = Vector2.left * speed * Time.deltaTime;
	}

    IEnumerator SpawnApple()
    {
        yield return new WaitForSeconds(randomSpawnRate);
        Instantiate(apple, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(1);
        spawnApple = true;
    }
}
