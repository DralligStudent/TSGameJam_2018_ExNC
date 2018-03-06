using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSScriptedEnc : MonoBehaviour {
    //the line of sight scripted encounter code
    public GameObject player;
    public bool encounterTrigger = false;//a variable for me to see if its working
    public bool encounterAlreadyDone = false;//a variable to make sure the player doesn't trigger the encounter multiple times
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<playerInteractScripted>().encounterAlreadyDone)
        {
            encounterAlreadyDone = true;
        }
        if (!player.GetComponent<moveOnGrid>().randomEncountTriggered && !encounterAlreadyDone)
        {
            if (transform.rotation.eulerAngles.y == 0)
            {
                if (transform.position.x == player.transform.position.x && player.transform.position.z > transform.position.z)
                {
                    encounterTrigger = true;
                    //move to prebattle
                    encounterAlreadyDone = true;
                }
            }
            else if (transform.rotation.eulerAngles.y == 90)
            {
                if (transform.position.z == player.transform.position.z && player.transform.position.x > transform.position.x)
                {
                    encounterTrigger = true;
                    //move to prebattle
                    encounterAlreadyDone = true;
                }
            }
            else if (transform.rotation.eulerAngles.y == 180)
            {
                if (transform.position.x == player.transform.position.x && player.transform.position.z < transform.position.z)
                {
                    encounterTrigger = true;
                    //move to prebattle
                    encounterAlreadyDone = true;
                }
            }
            else if (transform.rotation.eulerAngles.y == 270)
            {
                if (transform.position.z == player.transform.position.z && player.transform.position.x < transform.position.x)
                {
                    encounterTrigger = true;
                    //move to prebattle
                    encounterAlreadyDone = true;
                }
            }
        }

	}
}
