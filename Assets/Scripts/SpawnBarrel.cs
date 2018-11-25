using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrel : MonoBehaviour {

    public GameObject barrel;
    public Transform spawn;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            GameObject newBarrel = Instantiate(barrel, spawn.position, spawn.rotation);
        }
    }
}
