using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class _Ammo : ScriptableObject
{
    public int a_Cur_Ammount;
    protected enum a_enum_Type //defines the weapon that the ammo can be used inside
    {
        _Lazer,
        _Railgun,
        _Torpedo,
        _Arti
    };

    [SerializeField]
    protected a_enum_Type a_Type;

    protected void a_Set_Type(a_enum_Type n_Type)
    {
        a_Type = n_Type;
    }

    [Tooltip("Biases must add up to 2.0")]
    [SerializeField]
    protected float a_Shield_Bias = 1.0f, a_Hull_Bias = 1.0f; //out of 0 to 2, shield bias and hull bias must ALWAYS add up to 2
    
    [SerializeField]
    protected int a_Damage; //Actual Damage Value

    protected void a_Set_Bias(float x, float y)
    {
        float z = x + y;
        if (z >= 2.001 || z <= 1.999)//ensure to catch floating point errors
        {
            
            Debug.Log("ERROR, BIAS INCORRECT");
            return;
        }
        else
        {
            a_Shield_Bias = x; //set shield and hull bias values
            a_Hull_Bias = y;
        }
    }

    protected void a_Set_Damage(int x)
    {
        a_Damage = x;
    }

    public int a_Get_Damage()
    {
        return a_Damage;
    }

    public float a_Get_Shield_Bias()
    {
        return a_Shield_Bias;
    }

    public float a_Get_Hull_Bias()
    {
        return a_Hull_Bias;
    }
}
