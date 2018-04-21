using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getShipImages : MonoBehaviour {
    public Image[] PshipImages = new Image[8];
    public Image[] EshipImages = new Image[8];

    public BattleManager BM;

	// Use this for initialization
	void Start ()
    {
        BM = GameObject.Find("BattleManagerSystem").GetComponent<BattleManager>();
        i_Set_Images();
	}
	
	// Update is called once per frame
	void Update ()
    {


		
	}

    public void i_Set_Images()
    {
        for(int i = 0; i < PshipImages.Length; i++)
        {
            Debug.Log(BM.P_Ship_Array[i]);
            if (BM.P_Ship_Array[i] == null)
            {
                PshipImages[i].enabled = false;
            }
            else
            {
                Debug.Log(BM);
                if (BM.P_Ship_Array[i].gameObject != null)
                {
                    PshipImages[i].sprite = BM.P_Ship_Array[i].gameObject.GetComponent<Image>().sprite;
                }
            }

            if (BM.E_Ship_Array[i] == null)
            {
                EshipImages[i].enabled = false;
            }
            else
            {
                EshipImages[i].sprite = BM.E_Ship_Array[i].gameObject.GetComponent<Image>().sprite;
            }

            


            //EshipImages[i].sprite = BM.E_Ship_Array[i].gameObject.GetComponent<Image>().sprite;
        }
    }

    public void ImHide()
    {
        
    }
}
