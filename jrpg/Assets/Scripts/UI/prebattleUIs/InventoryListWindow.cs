using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListWindow : MonoBehaviour {

    public GameObject itemSlotPrefab;//ship slot prefab
    public GameObject emptyItemSlotPrefab;//empty slot prefab
    public GameObject content;//the area to fill with prefabs
    public ToggleGroup itemSlotToggleGroup;

    private int xPos = 0;
    private int yPos = 0;

    private GameObject itemSlot;
    private Text itemText;

    private Image itemImagePos;
    private Sprite itemImagePosSprite;
    private Image itemImage;
    private Sprite itemImageSprite;
    private GameObject testShip;

    private GameObject pInventory;//the player inventory game object in the scene
    public PlayerInventory playerInventory;//the player inventory script attached to the player inventory object
    int listNumber;//the amount of ships in the players inventory
    [HideInInspector]
    public float listLength;//the amount of ships + the extra space to display at the bottom
    private List<string> testlist;


    // Use this for initialization
    void Start () {
        pInventory = GameObject.Find("P_Inven");
        playerInventory = pInventory.GetComponent<PlayerInventory>();
        playerInventory.SetInven("Ships");

        testlist = playerInventory.DisplayInven();//test list is the players inventory

        listNumber = testlist.Count;
        listLength = listNumber- 0.48f;

        if (listLength < 0)
        {
            listLength = 0;
        }

        CreateInventorySlotsInWindow();
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnEnable()
    {
    
    }

    private void CreateInventorySlotsInWindow()
    {
        for (int i = 0; i < listNumber; i++)//fills the fleet inventory list (change 20 to the size of the players fleet)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = i.ToString();

            itemText = itemSlot.GetComponentInChildren<Text>() as Text;
            itemText.text = testlist[i];

            testShip = playerInventory.AccessShip(i);

            itemImagePos = itemSlot.GetComponentInChildren<Image>();//position to place ship image attached to itemSlotPrefab
            itemImage = testShip.GetComponent<Image>();//image of ship attached to ship prefab
            itemImageSprite = itemImage.sprite;//the sprite of the image of the ship attached to ship prefab
            itemImagePos.sprite = itemImageSprite;//sets the posision image to be equal to the ship image
            //itemImagePos = itemImage;

            //itemImagePos = testShip.GetComponent<Image>() as Image;

            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(content.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.height;
        }
        for (int i = 0; i < 4; i++)//fills the extra space at the bottom
        {
            itemSlot = (GameObject)Instantiate(emptyItemSlotPrefab);
            itemSlot.name = i.ToString();
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(content.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.height;
        }
        


    }
}
