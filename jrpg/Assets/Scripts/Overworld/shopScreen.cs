using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shopScreen : MonoBehaviour {
    public GameObject playerInvHolder;
    public int money;
    public bool itemBought, itemSold, itemNotFound, notEnoughMoney;

    public int testPerkIndex;
    // Use this for initialization
    
    void Start () {
        this.GetComponent<PlayerInventory>().SetInven("Perks");
        PlayerInventory.Perk perkins = new PlayerInventory.Perk();
        perkins.name = "Blah de blah blah";
        this.GetComponent<PlayerInventory>().AddItem(perkins);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            BuyPerk(ref money, 10, playerInvHolder, testPerkIndex);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(playerInvHolder.GetComponent<PlayerInventory>().AccessPerk(testPerkIndex));
            SellPerk(ref money, 10, playerInvHolder, testPerkIndex);
        }

    }

    void BuyPerk(ref int money, int price, GameObject functPlayerInv, int perkIndex)
    {
        functPlayerInv.GetComponent<PlayerInventory>().SetInven("Perks");
        if (this.GetComponent<PlayerInventory>().AccessPerk(perkIndex) != null)
        {
            if (price > money)
            {
                //Display not enough money message
                notEnoughMoney = true;
                return;
            }
            money -= price;
            functPlayerInv.GetComponent<PlayerInventory>().AddItem(this.GetComponent<PlayerInventory>().AccessPerk(perkIndex));
            itemBought = true;
        }
    }

    void SellPerk(ref int money, int price, GameObject functPlayerInv, int perkIndex)
    {
        functPlayerInv.GetComponent<PlayerInventory>().SetInven("Perks");
        if (functPlayerInv.GetComponent<PlayerInventory>().AccessPerk(perkIndex) == null)
        {
            //Display Item not in inv message
            itemNotFound = true;
            return;
        }
        money += price;
        functPlayerInv.GetComponent<PlayerInventory>().DeleteInvenItem(perkIndex);
        itemSold = true;
    }
}
