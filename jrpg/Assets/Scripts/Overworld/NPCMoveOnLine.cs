using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoveOnLine : MonoBehaviour {
    public bool oneToTwo = true; //if true object moves from position 1 to position 2 if false the other way around
    public int moveUpdateAmount = 10;// how many updates it takes to get to the new space
    public float gridSquareSize = 1;// how many unity units one movement is worth
    public Vector3 Position1;//one of the edgepoints of the path
    public Vector3 Position2;//the other edgepoint
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (oneToTwo)//checks the direction of the object
        {
            if (Mathf.Abs(Position2.z - transform.position.z) > Mathf.Abs(Position2.x - transform.position.x))//figures out if its further away in the x or z axis (currently stupidly flickers between rotations if not on a cardinal line)
            {
                if (transform.position.z < Position2.z)
                { 
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(0, 0, gridSquareSize / moveUpdateAmount);
                }
                else if (transform.position.z > Position2.z)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(0, 0, -gridSquareSize / moveUpdateAmount);
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

                }
            }
            else
            {
                if (transform.position.x < Position2.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(gridSquareSize / moveUpdateAmount, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else if (transform.position.x > Position2.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(-gridSquareSize / moveUpdateAmount, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                }
            }

        }
        else
        {
            if (Mathf.Abs(Position1.z - transform.position.z) > Mathf.Abs(Position1.x - transform.position.x))
            {
                if (transform.position.z < Position1.z)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(0, 0, gridSquareSize / moveUpdateAmount);
                }
                else if (transform.position.z > Position1.z)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(0, 0, -gridSquareSize / moveUpdateAmount);
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

                }
            }
            else
            {
                if (transform.position.x < Position1.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(gridSquareSize / moveUpdateAmount, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else if (transform.position.x > Position1.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(-gridSquareSize / moveUpdateAmount, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                }
            }

        }

        if (Mathf.Abs(Position2.z - transform.position.z) < 0.1f && Mathf.Abs(Position2.x - transform.position.x) < 0.1f)//changes direction of movement if object reaches an endpoint
        {
            oneToTwo = false;
        }
        if (Mathf.Abs(Position1.z - transform.position.z) < 0.1f && Mathf.Abs(Position1.x - transform.position.x) < 0.1f)
        {
            oneToTwo = true;
        }

    }

    void OnDrawGizmosSelected() // allows you to see the path in the unity editor
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Position1, Position2);
    }
}
