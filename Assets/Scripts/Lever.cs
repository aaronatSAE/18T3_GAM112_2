using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public GameObject leverAnim;
    public GameObject platform;
    public float speed = 0.1f;

    private float timer = 0f;
    private bool isLeverHit = false;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (isLeverHit)
        {
            
            if(timer< 1.9f)
            {
                platform.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            

        }

    }

    public void ActivateLever()
    {
        Instantiate(leverAnim, transform.position, transform.rotation);
        timer = 0f;
        isLeverHit = true;
        

    }
}
