using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHolder : MonoBehaviour
{
    public GameObject[] enemy_ships = new GameObject[8];
    public EnemyFleet e_fleet;

    private void Awake()
    {
        e_fleet = this.gameObject.AddComponent<EnemyFleet>();
    }

    // Use this for initialization
    void Start ()
    {
        foreach (GameObject G in enemy_ships)
        {
            e_fleet._Add_To_Fleet(G);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
