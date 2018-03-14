using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommander : MonoBehaviour {

    //naming conventions: Variables are camalCase. Functions CaptializeEachWord.
    //Get: Returns a VALUE, used for caculations in other functions/formulas. Show: Returns a STRING, used for showing information to the player via UI.

    //Level is based of an exp table- consider it a shorthand for total exp.
    public static int level = 1;
    int exp = 0;
    //This would also determine any species perks. Species does not change.
    private string species;
    public string flaw;
    //Power of perk increases with commander level. Perk Slots increase from 1 to 3 based on level.
    public string currentPerk1;
    public string currentPerk2;
    public string currentPerk3;
    //Morale can go from 0-100 (temporary). Determines fleet loyalty(flee chance) and perk strength (?)
    int fleetMorale = 50;
    //Rep can go from 0 to 100/1,000/10,000 (temporary). Determines shop availabilities, mission availabilities.
    //Losing battles drops it, winning battles raises it, cap increases per area unlocked(?).
    //Battles in further areas give more rep.
    int reputation = 25;
    int repCap = 100;
    //starting cash in "nuts" (temporary)
    int money = 1000;

    //Inventory slot, item name (?)
    IDictionary<int, string> playerInventory = new Dictionary<int, string>();

    //Would likely be used to help display status on menu
    void ShowLevel() { //have this stringstreamed, return a string to display //return level;
    }
    public static int GetLevel()
    {
        return level;
    }
    void GetExp() { }
    //and in shops
    void GetMoney() { }
    void GetRep() { }
    //Should we make this display as vague value?
    void GetMorale() { }
    void GetRepCap() { }
    //This would likely be attached to a menu/UI button
    void SetPerk() { }
    void GetPerks() { }
    void GetFlaw() { }

    int Flaw
    {
        get
        {
            return reputation * level;
        }

        set
        {
            reputation = value;
        }
    }


    //setters
    void ChangePerk() { }

    //exp thresholds are placeholders
    //switchcase for level gain
    /*Total up exp and gained exp, then drop current level into a switch. If exp triggers a new threshold, sets a new level and plays a level up animation (not yet implemented. Beta feature?)*/
    void AddExp(int expGained) {
        exp += expGained;
        switch (level)
        {
            case 1:
                if(exp > 1000)
                {
                    //PlayLevelUpAnim();
                    level = 2;
                }
                break;
            case 2:
                if (exp > 4000)
                {
                    //PlayLevelUpAnim();
                    level = 3;
                }
                break;
            case 3:
                if (exp > 10000)
                {
                    //PlayLevelUpAnim();
                    level = 4;
                }
                break;
            case 4:
                if (exp > 22000)
                {
                    //PlayLevelUpAnim();
                    level = 5;
                }
                break;
            case 5:
                if (exp > 46000)
                {
                    //PlayLevelUpAnim();
                    level = 6;
                }
                break;
            default:
                break;
        }
    }

    void AlterRep(int repDifference)
    {
        reputation += repDifference;
        Flaw = 5;
        if (Flaw == 25)
        {

        }
    }
    void AlterMorale(int moraleDifference)
    {
        fleetMorale += moraleDifference;
    }

    void AlterMoney(int moneyDifference)
    {
        money += moneyDifference;
    }

    void OnBattleVictory(int expGained, int moneyGained, int repGained)
    {
        AddExp(expGained);
        AlterMoney(moneyGained);
        AlterRep(repGained);
    }

    void OnBattleLoss(int repLost)
    {
        AlterRep(repLost);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
