using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shopScreen : MonoBehaviour {
    public List<string> playerInv;
    public int money;
    public bool itemBought, itemSold, itemNotFound, notEnoughMoney;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            BuyItem(ref money, 10, playerInv, "Poopy Shooty");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SellItem(ref money, 10, playerInv, "Poopy Shooty");
        }

    }

    void BuyItem(ref int money, int price, List<string> functPlayerInv, string item)
    {
        if (price > money)
        {
            //Display not enough money message
            notEnoughMoney = true;
            return;
        }
            money -= price;
        functPlayerInv.Add(item);
        itemBought = true;
    }

    void SellItem(ref int money, int price, List<string> functPlayerInv, string item)
    {
        if (!functPlayerInv.Contains(item))
        {
            //Display Item not in inv message
            itemNotFound = true;
            return;
        }
        money += price;
        functPlayerInv.Remove(item);
        itemSold = true;
    }
}
