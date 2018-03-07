using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject {

    //Player inventory is created once and goes though scene changes.
    //What should we do for other inventories? Random generation? Will they be saved?
    //Temp idea: Generate shop inventories based on level/rep/other factors. They are not saved, "Stock" is destroyed after the player leaves.
    //However, shops can only be accessed on a timer.(?)
    public static Inventory m_Inventory;
    //public Inventory m_inventory;

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
    class Item { };
    class Ship : Item { };
    class Gun : Item { };
    class Perk : Item { };

    IList<Ship> shipInven = new List<Ship>();
    IList<Gun> gunInven = new List<Gun>();
    IList<Perk> perkInven = new List<Perk>();

    List<int> errorList = new List<int>();

    //Sets the current item type/type to be worked with.
    //Accesses the InvenRef Dictionary with the provided string to give an associated item type number.
    void SetInven(string itemTypeName)
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

    void deleteInvenItem(int inventoryType, int selectedItemIndex)
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

    //Ask about inheretance. Will need to create seperate functions otherwise...
    void AddItem(int inventoryType, Item other)
    {
        switch (inventoryType)
        {
            case (int)InvenKeys.e_perk:
                if (perkInven[selectedItemIndex] != null)
                {
                    perkInven.Add(other);
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
        if (m_Inventory == null)
        {
            m_Inventory = this;
        }
        DontDestroyOnLoad(this);

        //This populates the inventory reference database. Don't touch.
        InvenRef.Add(new KeyValuePair<string, int>("Default", (int)InvenKeys.e_default));
        InvenRef.Add(new KeyValuePair<string, int>("Perks", (int)InvenKeys.e_perk));
        InvenRef.Add(new KeyValuePair<string, int>("Ships", (int)InvenKeys.e_ship));
        InvenRef.Add(new KeyValuePair<string, int>("Guns", (int)InvenKeys.e_gun));
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
