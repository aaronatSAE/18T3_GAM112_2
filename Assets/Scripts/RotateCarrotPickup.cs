using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCarrotPickup : MonoBehaviour {


    private float rotateY;

    
    // Update is called once per frame
    void Update()
    {
        rotateY += 3f;
        transform.eulerAngles = new Vector3(0f, rotateY, -45f);
    }

    


    

    
}
