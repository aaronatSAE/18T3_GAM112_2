using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirds : MonoBehaviour {

    public GameObject bird;
    public Transform spawnPoint;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnBird", 4f, 4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnBird()
    {
        Instantiate(bird, spawnPoint.position, spawnPoint.rotation);
    }
}
