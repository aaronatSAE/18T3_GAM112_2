using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudMover : MonoBehaviour {

    public Transform cam;
	
	// Update is called once per frame
	void Update () {
        Vector2 newPos = new Vector2(cam.position.x, cam.position.y + 5f);
        transform.position = newPos;
		
	}
}
