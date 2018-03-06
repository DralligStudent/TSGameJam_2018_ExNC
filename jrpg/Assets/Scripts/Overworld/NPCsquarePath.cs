using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsquarePath : MonoBehaviour {
    public Vector3 Position1;//the four points of the rectangle 
    public Vector3 Position2;
    public Vector3 Position3;
    public Vector3 Position4;
    public int travelingTo = 2;// the position the object is traveling to
    public int moveUpdateAmount = 10;// how many updates it takes to get to the new space
    public float gridSquareSize = 1;// how many unity units one movement is worth
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (travelingTo == 1)// sees which position is the target on and moves towards it
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
        else if(travelingTo == 2)
        {
            if (Mathf.Abs(Position2.z - transform.position.z) > Mathf.Abs(Position2.x - transform.position.x))
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
        else if(travelingTo == 3)
        {
            if (Mathf.Abs(Position3.z - transform.position.z) > Mathf.Abs(Position3.x - transform.position.x))
            {
                if (transform.position.z < Position3.z)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(0, 0, gridSquareSize / moveUpdateAmount);
                }
                else if (transform.position.z > Position3.z)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(0, 0, -gridSquareSize / moveUpdateAmount);
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

                }
            }
            else
            {
                if (transform.position.x < Position3.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(gridSquareSize / moveUpdateAmount, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else if (transform.position.x > Position3.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(-gridSquareSize / moveUpdateAmount, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                }
            }
        }
        else
        {
            if (Mathf.Abs(Position4.z - transform.position.z) > Mathf.Abs(Position4.x - transform.position.x))
            {
                if (transform.position.z < Position4.z)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(0, 0, gridSquareSize / moveUpdateAmount);
                }
                else if (transform.position.z > Position4.z)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(0, 0, -gridSquareSize / moveUpdateAmount);
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

                }
            }
            else
            {
                if (transform.position.x < Position4.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(gridSquareSize / moveUpdateAmount, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else if (transform.position.x > Position4.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.Translate(-gridSquareSize / moveUpdateAmount, 0, 0);
                    transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                }
            }
        }
        if (Mathf.Abs(Position1.z - transform.position.z) < 0.1f && Mathf.Abs(Position1.x - transform.position.x) < 0.1f)//changes destinatation point if the current one is reached
        {
            travelingTo = 2;
        }
        if (Mathf.Abs(Position2.z - transform.position.z) < 0.1f && Mathf.Abs(Position2.x - transform.position.x) < 0.1f)
        {
            travelingTo = 3;
        }
        if (Mathf.Abs(Position3.z - transform.position.z) < 0.1f && Mathf.Abs(Position3.x - transform.position.x) < 0.1f)
        {
            travelingTo = 4;
        }
        if (Mathf.Abs(Position4.z - transform.position.z) < 0.1f && Mathf.Abs(Position4.x - transform.position.x) < 0.1f)
        {
            travelingTo = 1;
        }
    }

    void OnDrawGizmosSelected()//draws the square path in the unity editor
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Position1, Position2);
        Gizmos.DrawLine(Position2, Position3);
        Gizmos.DrawLine(Position3, Position4);
        Gizmos.DrawLine(Position4, Position1);
    }
}
