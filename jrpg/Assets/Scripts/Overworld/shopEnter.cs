using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopEnter : MonoBehaviour {
    public GameObject player;
    public bool shopTriggered;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent<Collider>().bounds.Intersects(this.GetComponent<Collider>().bounds))
        {
            shopTriggered = true;
            //move to shop
        }
	}
}
