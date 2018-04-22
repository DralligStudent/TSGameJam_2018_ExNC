using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageCurrentShip : MonoBehaviour {


    private Image spritePositionImage;

    private Image itemImage;
    private Sprite itemSprite;
    
    private int selectedShip;

    private GameObject pInventory;//the player inventory game object in the scene
    public PlayerInventory playerInventory;//the player inventory script attached to the player inventory object
    private List<string> testlist;
    private GameObject testShip;


    // Use this for initialization
    void Start () {

        spritePositionImage = GetComponent<Image>();//position to place ship image attached to itemSlotPrefab
        pInventory = GameObject.Find("P_Inven");
        playerInventory = pInventory.GetComponent<PlayerInventory>();
        playerInventory.SetInven("Ships");
        testlist = playerInventory.DisplayInven();
    }
	
	// Update is called once per frame
	void Update () {
        selectedShip = PlayerPrefs.GetInt("selectedShip");
        testShip = playerInventory.AccessShip(selectedShip);

        itemImage = testShip.GetComponent<Image>();//image of ship attached to ship prefab
        itemSprite = itemImage.sprite;//the sprite of the image of the ship attached to ship prefab
        spritePositionImage.sprite = itemSprite;//sets the posision image to be equal to the ship image
    }
}
