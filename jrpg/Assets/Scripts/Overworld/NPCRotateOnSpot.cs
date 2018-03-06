using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRotateOnSpot : MonoBehaviour {

    public int count, rotateUpdateAmount = 100;
    public bool antiClockwise;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (count > rotateUpdateAmount)//every amount of updates in rotateUpdateAmount makes object rotate 90 degrees in the direction they are set to
        {
            if (!antiClockwise)
            {
                if (transform.rotation.eulerAngles.y == 0)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else if (transform.rotation.eulerAngles.y == 90)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                }
                else if (transform.rotation.eulerAngles.y == 180)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                }
                else if (transform.rotation.eulerAngles.y == 270)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
            }
            else
            {
                if (transform.rotation.eulerAngles.y == 0)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                }
                else if (transform.rotation.eulerAngles.y == 90)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
                else if (transform.rotation.eulerAngles.y == 180)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else if (transform.rotation.eulerAngles.y == 270)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                }
            }
            count = 0;
        }
        count++;

	}
}
