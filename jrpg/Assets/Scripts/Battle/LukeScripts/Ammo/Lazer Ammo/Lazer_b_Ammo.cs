using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_b_Ammo : _Lazer_Ammo
{
    private void Awake()
    {
        base.Start();
    }

    // Use this for initialization
    void Start ()
    {
        //base.Start();
        a_Set_Bias(1.2f, 0.8f);
        a_Set_Damage(25);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
