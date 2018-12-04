using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerPosition : MonoBehaviour {

    public float height;
    public Transform player;

	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(player.position.x, height, transform.position.z);

        transform.position = pos;
		
	}
}
