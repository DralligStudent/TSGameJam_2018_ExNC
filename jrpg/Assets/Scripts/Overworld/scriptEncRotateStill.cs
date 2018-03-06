using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEncRotateStill : MonoBehaviour {
    public int count, turnDelay = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (count >= turnDelay)
        {
            if (transform.rotation.eulerAngles.y == 0)
            {
                transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
            }
            else if (transform.rotation.eulerAngles.y == 90)
            {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            }
            else if (transform.rotation.eulerAngles.y == 180)
            {
                transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
            }
            else if (transform.rotation.eulerAngles.y == 270)
            {
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            }
            count = 0;
        }
        count++;
	}
}
