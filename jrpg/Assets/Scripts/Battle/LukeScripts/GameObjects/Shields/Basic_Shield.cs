using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Shield : _Shield
{

	// Use this for initialization
	void Start ()
    {
        sh_Set_Shield(100);
        sh_Set_Recharge(10);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
