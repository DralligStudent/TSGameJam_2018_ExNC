using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractScripted : MonoBehaviour {
    public GameObject player;
    public bool encounterTrigger = false;//a variable for me to see if its working
    public bool encounterAlreadyDone = false;//a variable to make sure the player doesn't trigger the encounter multiple times
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
            if (this.GetComponent<LOSScriptedEnc>().encounterAlreadyDone)
            {
                encounterAlreadyDone = true;
            }
            if (!player.GetComponent<moveOnGrid>().randomEncountTriggered && !encounterAlreadyDone)
            {
            if(player.transform.position.x ==transform.position.x && player.transform.position.z -transform.position.z == -1 && player.transform.rotation.eulerAngles.y == 0 && Input.GetKeyDown(KeyCode.Return))
            {
                encounterTrigger = true;
                //move to prebattle
                encounterAlreadyDone = true;
            }
            if (player.transform.position.z == transform.position.z && player.transform.position.x - transform.position.x == -1 && player.transform.rotation.eulerAngles.y == 90 && Input.GetKeyDown(KeyCode.Return))
            {
                encounterTrigger = true;
                //move to prebattle
                encounterAlreadyDone = true;
            }
            if (player.transform.position.x == transform.position.x && player.transform.position.z - transform.position.z == 1 && player.transform.rotation.eulerAngles.y == 180 && Input.GetKeyDown(KeyCode.Return))
            {
                encounterTrigger = true;
                //move to prebattle
                encounterAlreadyDone = true;
            }
            if (player.transform.position.z == transform.position.z && player.transform.position.x - transform.position.x == 1 && player.transform.rotation.eulerAngles.y == 270 && Input.GetKeyDown(KeyCode.Return))
            {
                encounterTrigger = true;
                //move to prebattle
                encounterAlreadyDone = true;
            }
        }
	}
}
