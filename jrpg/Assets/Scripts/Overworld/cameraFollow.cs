using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public GameObject target;//the object the camera is tracking to follow
    public float distY= 10;//how far above the object the camera is (orthographic makes obsolete? consider removing)
    public float screenEdgeTop, screenEdgeRight, screenEdgeBottom, screenEdgeLeft;//the parts of the screen which will stick in place to avoid viewing the void
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //the three coordinates of the target object
        float targetX = target.transform.position.x;
        float targetZ = target.transform.position.z;
        float targetY = target.transform.position.y;
        //these if statements lock the camera to the screen
        if (targetX > screenEdgeRight)
        {
            targetX = screenEdgeRight;
        }
        if (targetX < screenEdgeLeft)
        {
            targetX = screenEdgeLeft;
        }
        if (targetZ > screenEdgeTop)
        {
            targetZ = screenEdgeTop;
        }
        if (targetZ < screenEdgeBottom)
        {
            targetZ = screenEdgeBottom;
        }
        // this makes the camera remain distY away from the object (maybe obsolete?)
        targetY += distY;
        // sets the camera to the new coordinates
        transform.position = new Vector3(targetX, targetY, targetZ);
    }
}
