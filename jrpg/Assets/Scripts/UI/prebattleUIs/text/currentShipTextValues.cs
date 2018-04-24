using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentShipTextValues : MonoBehaviour {

    public Text[] text = new Text[7];

    private _Ship currentShip;
    private int selectedShip;

    private GameObject pInventory;//the player inventory game object in the scene
    public PlayerInventory playerInventory;//the player inventory script attached to the player inventory object
    private List<string> testlist;

    // Use this for initialization
    void Start () {

        //text = GetComponent<Text>() as Text;
        pInventory = GameObject.Find("P_Inven");
        playerInventory = pInventory.GetComponent<PlayerInventory>();
        playerInventory.SetInven("Ships");
        testlist = playerInventory.DisplayInven();
    }
	
    void UpdateShipText()
    {
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            currentShip = playerInventory.AccessShip(PlayerPrefs.GetInt("selectedShip")).GetComponent<_Ship>();

            var x = currentShip.s_Get_Names();
            var y = currentShip.s_Get_Values();

            text[0] = x[0] as Text;
            text[1] = x[1] as Text;

            text[2] = y[0] as Text;
            text[3] = y[1] as Text;
            text[4] = y[2] as Text;
            text[5] = y[3] as Text;
            text[6] = y[4] as Text;
        }
    }

	// Update is called once per frame
	void Update () {
        selectedShip = PlayerPrefs.GetInt("selectedShip");
        UpdateShipText();
        //text.text = testlist[selectedShip];
	}
}
