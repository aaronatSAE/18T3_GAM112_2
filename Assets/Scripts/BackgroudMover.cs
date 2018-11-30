using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudMover : MonoBehaviour {

    public Transform player;
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(player.position.x, player.position.y + 5f, player.position.z);
        transform.position = newPos;
		
	}
}
