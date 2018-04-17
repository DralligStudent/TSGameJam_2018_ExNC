using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour {

	public GameObject fleet, prebattleSetup;
	public GameObject currentlySelected, shipStats, fleetInventory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Q))
		{
			currentlySelected.SetActive (false); shipStats.SetActive (false); fleetInventory.SetActive (false);//hides current menus
			fleet.SetActive (true); prebattleSetup.SetActive (true);//shows the previous menus
		}
		
	}
}
