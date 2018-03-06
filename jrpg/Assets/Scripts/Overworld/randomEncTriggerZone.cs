using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomEncTriggerZone : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // this if statement checks whether the player is inside the space of xy plane of the game object plane the scripts attached to 
        if (player.transform.position.z <= transform.position.z + (5 * transform.localScale.z) && player.transform.position.z >= transform.position.z - (5 * transform.localScale.z) && player.transform.position.x <= transform.position.x + (5 * transform.localScale.x) && player.transform.position.x >= transform.position.x - (5 * transform.localScale.x) && !player.GetComponent<moveOnGrid>().isInRandomEncounterArea)
        {
            //this changes the boolean in the players move function to display it is now allowed get random encounters
            player.GetComponent<moveOnGrid>().isInRandomEncounterArea = true;
        }
	}
}
