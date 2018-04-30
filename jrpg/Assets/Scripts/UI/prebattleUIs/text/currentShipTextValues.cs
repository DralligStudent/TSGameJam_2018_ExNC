using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentShipTextValues : MonoBehaviour {

    public Text[] text = new Text[7];

    public Text[] weapontext1 = new Text[5];
    public Text[] weapontext2 = new Text[5];
    public Text[] weapontext3 = new Text[5];
    public Text[] weapontext4 = new Text[5];





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
            currentShip = playerInventory.AccessShip(PlayerPrefs.GetInt("selectedShip")).GetComponent<publicShip>().ShipClass;

            string[] x = currentShip.s_Get_Names();
            float[] y = currentShip.s_Get_Val();

            text[0].text = testlist[selectedShip];
            text[1].text = x[1];

            text[2].text = y[0].ToString();
            text[3].text = y[1].ToString();
            text[4].text = y[2].ToString();
            text[5].text = y[3].ToString();
            text[6].text = y[4].ToString();

            //for (int i = 0; i < 5; i++)
            //{
            /*
                weapontext[0].text = currentShip.s_Weapons[0].name.ToString();
                weapontext[1].text = currentShip.s_Weapons[0].w_Get_Dam_H().ToString();
                weapontext[2].text = currentShip.s_Weapons[0].w_Get_Dam_S().ToString();
                weapontext[3].text = currentShip.s_Weapons[0].w_Type.ToString();
                weapontext[4].text = currentShip.s_Weapons[0].w_Ammo.ToString();
              }
            */
            if (currentShip.s_Weapons[0] != null)
            {
                weapontext1[0].text = currentShip.s_Weapons[0].name.ToString();
                weapontext1[1].text = currentShip.s_Weapons[0].w_Get_Dam_H().ToString();
                weapontext1[2].text = currentShip.s_Weapons[0].w_Get_Dam_S().ToString();
                weapontext1[3].text = currentShip.s_Weapons[0].w_Type.ToString();
                weapontext1[4].text = currentShip.s_Weapons[0].w_Ammo.ToString();
            }
            if (currentShip.s_Weapons[1])
            {
                weapontext2[0].text = currentShip.s_Weapons[1].name.ToString();
                weapontext2[1].text = currentShip.s_Weapons[1].w_Get_Dam_H().ToString();
                weapontext2[2].text = currentShip.s_Weapons[1].w_Get_Dam_S().ToString();
                weapontext2[3].text = currentShip.s_Weapons[1].w_Type.ToString();
                weapontext2[4].text = currentShip.s_Weapons[1].w_Ammo.ToString();
            }
            if (currentShip.s_Weapons[2] != null)
            {
                weapontext3[0].text = currentShip.s_Weapons[2].name.ToString();
                weapontext3[1].text = currentShip.s_Weapons[2].w_Get_Dam_H().ToString();
                weapontext3[2].text = currentShip.s_Weapons[2].w_Get_Dam_S().ToString();
                weapontext3[3].text = currentShip.s_Weapons[2].w_Type.ToString();
                weapontext3[4].text = currentShip.s_Weapons[2].w_Ammo.ToString();
            }
            if (currentShip.s_Weapons[3] != null)
            {
                weapontext4[0].text = currentShip.s_Weapons[3].name.ToString();
                weapontext4[1].text = currentShip.s_Weapons[3].w_Get_Dam_H().ToString();
                weapontext4[2].text = currentShip.s_Weapons[3].w_Get_Dam_S().ToString();
                weapontext4[3].text = currentShip.s_Weapons[3].w_Type.ToString();
                weapontext4[4].text = currentShip.s_Weapons[3].w_Ammo.ToString();
            }
        }
    }

	// Update is called once per frame
	void Update () {
        selectedShip = PlayerPrefs.GetInt("selectedShip");
        UpdateShipText();
        //text.text = testlist[selectedShip];
	}
}
