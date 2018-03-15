using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    //Player inventory is created once and goes though scene changes.
    //What should we do for other inventories? Random generation? Will they be saved?
    //Temp idea: Generate shop inventories based on level/rep/other factors. They are not saved, "Stock" is destroyed after the player leaves.
    //However, shops can only be accessed on a timer.(?)

    //To use: call SetInven("Inventory name"), then call DisplayInven().
    //Use the index of the wanted item's string in the returned list with other inventory functions. 

    public static PlayerInventory m_Player_Inventory;
    public PlayerInventory m_inventory;

    public bool isPlayerInven;

    //Enum for safer access of inventory elements. e_defualt should always remain as the first entry for error handling reasons (since that makes it 0).
    public enum InvenKeys {
        e_default,
        e_perk,
        e_ship,
        e_gun,
        e_module,
        e_recovery,
        e_material
    };
    //Use last element in enum InvenKeys to obtain the total indexes (if we need it)
    int totalIndexInvenKeys = (int)InvenKeys.e_material;

    //This following dictionary is intended to allow users to access the inventories by name (string)
    //To elaborate, we allow the user to give a string to the inventory, which converts it to an int via the dictionary.
    //The enum InvenKeys helps for readability and to keep those ints constant.
    /*
    CURRENT RELEVENT NAMES/STRINGS ARE AS FOLLOWS:
    "Perks"
    "Guns"
    "Ships"
    */
    IDictionary<string, int> InvenRef = new Dictionary<string, int>();
    int inventoryType;

    //temporary forward declarations
    public class Item { public string name; };
    //public class Ship : Item { };
    public class Gun : Item { };
    public class Perk : Item { };

    IList<GameObject> shipInven = new List<GameObject>();
    IList<Gun> gunInven = new List<Gun>();
    IList<Perk> perkInven = new List<Perk>();

    //Sets the current item type/type to be worked with.
    //Accesses the InvenRef Dictionary with the provided string to give an associated item type number.
    public void SetInven(string itemTypeName)
    {
        int inventoryTypeIndex;
        if (InvenRef.TryGetValue(itemTypeName, out inventoryTypeIndex))
        {
            inventoryType = inventoryTypeIndex;
        }
        else
        {
            Debug.Log("Error. Requested inventory type not found.");
            inventoryType = (int)InvenKeys.e_default;
        }
    }

    //Returns a list of strings, each index holding the name of an item.
    //This index should match the index location of the list the item is stored in.
    //You can use that index to access that specific item.
    public List<string> DisplayInven()
    {
        List<string> listout = new List<string>();
        switch (inventoryType)
        {
            case (int)InvenKeys.e_perk:
                for (int i =0; i<perkInven.Count; i++)
                {
                    listout.Add(perkInven[i].name);
                }
                return listout;
                //break;
            case (int)InvenKeys.e_ship:
                for (int i = 0; i < shipInven.Count; i++)
                {
                    listout.Add(shipInven[i].name);
                }
                return listout;
                //break;
            case (int)InvenKeys.e_gun:
                for (int i = 0; i < gunInven.Count; i++)
                {
                    listout.Add(gunInven[i].name);
                }
                return listout;
                //break;
            default:
                listout.Add("Error displaying Inventory.");
                return listout;
                //break;
        }
    }

    //Directly returns the item in question.
    //Unsure if a copy or pointer is returned. As such, unsure if modifications to the returned item will affect the item in the inventory.
    //TESTING REQUIRED.
    //Seperate functions required because of c# strong typing.
    public Perk AccessPerk(int selectedItemIndex)
    {

        return perkInven[selectedItemIndex];

    }
    public GameObject AccessShip(int selectedItemIndex)
    {
        return shipInven[selectedItemIndex];
    }
    public Gun AccessGun(int selectedItemIndex)
    {
        return gunInven[selectedItemIndex];
    }

    //Overloaded fuctions to add items to their specific inventories.
    //Could be improved via inheritance and interfaces? Ask tutors
    public void AddItem(Perk other)
    {
        if (inventoryType == (int)InvenKeys.e_perk)
        {
            perkInven.Add(other);
            Debug.Log("entered if");
        }
        if (perkInven.Count > 0)
        {
            Debug.Log("perk added");
        }
    }

    public void AddItem(GameObject other)
    {
        if (inventoryType == (int)InvenKeys.e_ship)
        {
            shipInven.Add(other);
        }
        
    }

    public void AddItem(Gun other)
    {
        if (inventoryType == (int)InvenKeys.e_gun)
        {
            gunInven.Add(other);
        }
        
    }


    public void DebugAddShipButton()
    {
        SetInven("Ships");
        GameObject testy = new GameObject("Namey");
        m_inventory.AddItem(testy);
        Debug.Log("Added a ship to the inventory.");
        //Destroy(testy);
    }
    public void DebugTestAccessShipButton()
    {
        SetInven("Ships");
        GameObject Shipy = m_inventory.shipInven[3];
        Debug.Log(m_inventory.shipInven[3]);
        Debug.Log(Shipy);
    }

    //Use the index from DisplayInven() to make sure the correct item is selected.
    public void DeleteInvenItem(int selectedItemIndex)
    {
        switch (inventoryType)
        {
            case (int)InvenKeys.e_perk:
                if (perkInven[selectedItemIndex] != null)
                {
                    perkInven.RemoveAt(selectedItemIndex);
                }
                else
                {
                    Debug.Log("Error. Perk Inventory not found.");
                }
                break;
            case (int)InvenKeys.e_ship:
                if (shipInven[selectedItemIndex] != null)
                {
                    shipInven.RemoveAt(selectedItemIndex);
                }
                else
                {
                    Debug.Log("Error. Ship Inventory not found.");
                }
                break;
            case (int)InvenKeys.e_gun:
                if (gunInven[selectedItemIndex] != null)
                {
                    gunInven.RemoveAt(selectedItemIndex);
                }
                else
                {
                    Debug.Log("Error. Gun Inventory not found.");
                }
                break;
            default:
                break;
        }

    }

    //Start section: Tutor examples given
    //bool LoadData
    //{
    //    get
    //    {
    //        return loaddata;
    //    }
    //    set
    //    {

    //    }
    //}

    ////public class ItemType
    ////{
    ////}

    //public interface IItem


    //{
    //    int Item
    //    {
    //        get;
    //        set;
    //    }
    //}

    //public string[] AllItems
    //    {
    //        get
    //        {
    //            for 
    //        }
    //    }

    //bool toggle_thingy;
    //public int Thing
    //{
    //    get
    //    {
    //        if (toggle_thingy)
    //        {

    //        }
    //        else
    //        {

    //        }

    //        return ((toggle_thingy) ? 5: 4);
    //    }

    //    set
    //    {
    //        toggle_thingy = (value % 1 == 0) ? true : false;

    //    }
    //}

    //End Section: Tutor examples given

    //Pass a casted enum of InvenKeys into this.


    void Awake()
    {
        //Creates a singleton object. This Object will exsist between unity scene loads.
        //Note: Set this as the player inventory/set isPlayerInven in Unity's UI.
        if (m_Player_Inventory == null && isPlayerInven)
        {
            m_Player_Inventory = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            m_inventory = this;
        }
    }

    // Use this for initialization
    void Start () {
        //This populates the inventory reference database. Don't touch.
        InvenRef.Add(new KeyValuePair<string, int>("Default", (int)InvenKeys.e_default));
        InvenRef.Add(new KeyValuePair<string, int>("Perks", (int)InvenKeys.e_perk));
        InvenRef.Add(new KeyValuePair<string, int>("Ships", (int)InvenKeys.e_ship));
        InvenRef.Add(new KeyValuePair<string, int>("Guns", (int)InvenKeys.e_gun));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J)){
            DebugAddShipButton();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            DebugTestAccessShipButton();
        }
	}
}
