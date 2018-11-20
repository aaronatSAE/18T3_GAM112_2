using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public GameObject leverAnim;
    public GameObject platform;
    public float speed = 0.1f;

    private float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ActivateLever()
    {
        Instantiate(leverAnim, transform.position, transform.rotation);
        
        while(timer < 3f)
        {
            platform.transform.Translate(Vector3.down * speed * Time.deltaTime);
            timer += Time.deltaTime;
        }

    }
}
