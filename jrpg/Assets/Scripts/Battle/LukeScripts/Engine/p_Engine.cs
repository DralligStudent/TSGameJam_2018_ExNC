using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Engine : _Engine
{
    
	// Use this for initialization
	void Start ()
    {
        e_Set_Class(e_Class_Enum.e_Fighter);
        e_Set_Power(1000);
        e_Set_Boost(5);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
