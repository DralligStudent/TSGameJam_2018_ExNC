using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentShipName : MonoBehaviour {

    public Text text;
    private int selectedShip;

    private GameObject pInventory;//the player inventory game object in the scene
    public PlayerInventory playerInventory;//the player inventory script attached to the player inventory object
    private List<string> testlist;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>() as Text;
        pInventory = GameObject.Find("P_Inven");
        playerInventory = pInventory.GetComponent<PlayerInventory>();
        playerInventory.SetInven("Ships");
        testlist = playerInventory.DisplayInven();
    }
	
	// Update is called once per frame
	void Update () {
        selectedShip = PlayerPrefs.GetInt("selectedShip");
        text.text = testlist[selectedShip];
	}
}
