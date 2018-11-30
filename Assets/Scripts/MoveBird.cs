using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBird : MonoBehaviour {

    
    private Rigidbody2D rb;


	// Use this for initialization
	void Awake ()
    {
        
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnBird()
    {

    }
}
