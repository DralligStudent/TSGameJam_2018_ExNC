using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnGrid : MonoBehaviour {

    private int count = 0;//To make sure the ship only moves one grid space at a time
    public float gridSquareSize = 1;//The size of each grid square in unity's units
    public int moveDelay = 30;//The amount of updates before the object can move again after moving
    public Vector3 originalCoord;//The coordinates before the ship moves
    public Vector3 targetCoord;//The coordinates where the ship will move towards
    public int moveUpdateAmount = 10;//how many updates it takes to get to destintaion tile should be less than move delay to avoid complications
    public bool isInRandomEncounterArea = false; // keeps track of whether the player is in a area of random encounters
    System.Random randomNum = new System.Random();// for random numbers
    public bool randomEncountTriggered = false; //way of my checking if its working
    public int randEncChance = 4; // sets the chance of encounter at 1/value eg a value of 4 would make an encounter roughly every 4 squares
    public LayerMask impassMask = 1 << 8; // layer of impassible objects
    public Vector3 halfBoundingDimensions;//the size of each dimension of the collision detection  
    void Start () {
        count = moveDelay; //This allows the player to move this object instant that it exists while maintaining the gap between movements later
        targetCoord = transform.position; //The targetCoord needs to be initialised at the begining
        halfBoundingDimensions.x = gridSquareSize / 2 - 0.01f;
        halfBoundingDimensions.y = 1000;
        halfBoundingDimensions.z = gridSquareSize / 2 - 0.01f;
    }

    // Update is called once per frame
    void Update() {
        //these if statements nestled in the count if statement set the target coordinate
        //W and S are taken as +ve and -ve movement in the z axis respectively and so is D and A with the x axis 


        if (count >= moveDelay)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                originalCoord = transform.position;
                targetCoord.z = transform.position.z + gridSquareSize;
                count = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                originalCoord = transform.position;
                targetCoord.x = transform.position.x + gridSquareSize;
                count = 0;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                originalCoord = transform.position;
                targetCoord.z = transform.position.z - gridSquareSize;
                count = 0;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                originalCoord = transform.position;
                targetCoord.x = transform.position.x - gridSquareSize;
                count = 0;
            }
        }
        else
        {
            count++;
        }
        // these if statements rotate then move the object to the target over the course of moveUpdateAmount updates
        if (transform.position.z < targetCoord.z)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(0, 0, gridSquareSize / moveUpdateAmount);

        }
        else if (transform.position.z > targetCoord.z)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(0, 0, -gridSquareSize / moveUpdateAmount);
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

        }
        else if (transform.position.x < targetCoord.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(gridSquareSize / moveUpdateAmount, 0, 0);
            transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
        }
        else if (transform.position.x > targetCoord.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(-gridSquareSize / moveUpdateAmount, 0, 0);
            transform.rotation = Quaternion.AngleAxis(270, Vector3.up);


        }


        //when the object gets to the target space these functions round to the nearest integer to account for binary rounding errors
        if (transform.position.z - targetCoord.z <= 0.1f && transform.position.z - targetCoord.z >= -0.1f && transform.position.z != targetCoord.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
            if (isInRandomEncounterArea && randomNum.Next(randEncChance) == 0)// this and its counterpart in the next if statement works out after a move is finished whether a random encounter happens based on if the player is in area and if the random number is 1
            {
                randomEncountTriggered = true;
                //move to prebattle
            }

        }
        if (transform.position.x - targetCoord.x <= 0.1f && transform.position.x - targetCoord.x >= -0.1f && transform.position.x != targetCoord.x)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
            if (isInRandomEncounterArea && randomNum.Next(randEncChance) == 0)
            {
                randomEncountTriggered = true;
                //move to prebattle
            }
        }
        randomEncountTriggered = false;

        if (Physics.OverlapBox(transform.position, halfBoundingDimensions, Quaternion.identity, impassMask).Length >0)
        {
            targetCoord = originalCoord;
            transform.position = originalCoord;
            count = 0;
        }

    }
}
