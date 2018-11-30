using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    public LayerMask layer;
    private GameObject playerStats;

	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindGameObjectWithTag("ScriptManager");
		
	}
	
	// Update is called once per frame
	void Update () {

        //RaycastHit ray = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layer);

		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            playerStats.GetComponent<PlayerStats>().life -= 1;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
