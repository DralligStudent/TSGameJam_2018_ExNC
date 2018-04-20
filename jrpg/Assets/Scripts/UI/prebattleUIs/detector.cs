using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detector : MonoBehaviour {

    public GameObject fleet, prebattleSetup;
    public GameObject currentlySelected, shipStats, fleetInventory;

    private string shipNumberString;
    public int currentShipNumber;

    private PlayerInventory playerInventory;
    [HideInInspector]
    public Image targetImage;

	// Use this for initialization
	void Start () {
        playerInventory = GameObject.Find("P_Inven").GetComponent<PlayerInventory>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Q))
		{
			currentlySelected.SetActive (false); shipStats.SetActive (false); fleetInventory.SetActive (false);//hides current menus
			fleet.SetActive (true); prebattleSetup.SetActive (true);//shows the previous menus
		}

        if (Input.GetKeyDown(KeyCode.E))
        {
            //formationindex=selectedship
            GameObject preBattleState = GameObject.Find("PreBattleState");
            preBattleState.GetComponent<PreBattleState>().setInventoryIndex(PlayerPrefs.GetInt("selectedShip"));
            preBattleState.GetComponent<PreBattleState>().setBattleFormation();

            GameObject testShip = playerInventory.AccessShip(preBattleState.GetComponent<PreBattleState>().battleFormation[preBattleState.GetComponent<PreBattleState>().getFormationIndex()]);
            Image shipImage = testShip.GetComponent<Image>();
            targetImage.sprite = shipImage.sprite;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision"); 
        shipNumberString = other.name;
        int.TryParse(shipNumberString, out currentShipNumber);
        PlayerPrefs.SetInt("selectedShip", currentShipNumber);
    }
}
