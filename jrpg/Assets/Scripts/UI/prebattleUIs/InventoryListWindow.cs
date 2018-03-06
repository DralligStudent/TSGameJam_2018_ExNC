using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListWindow : MonoBehaviour {

    public GameObject itemSlotPrefab;
    public GameObject content;
    public ToggleGroup itemSlotToggleGroup;

    private int xPos = 0;
    private int yPos = 0;
    private GameObject itemSlot;

	// Use this for initialization
	void Start () {
        CreateInventorySlotsInWindow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateInventorySlotsInWindow()
    {
        for (int i = 0; i < 20; i++)//change 20 to the size of the players fleet
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = i.ToString();
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(content.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.height;
        }
        


    }
}
