using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _Lazer_Ammo : _Ammo
{
    // Use this for initialization
	protected void Start ()
    {
        a_Set_Type(a_enum_Type._Lazer);
        //Debug.Log(a_Type);

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
