using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testDifficulty : MonoBehaviour {

	public Text text;
	private string difficulty;

	// Use this for initialization
	void Start () {
		difficulty = PlayerPrefs.GetString ("difficulty");
		text = GetComponent<Text> () as Text;
		text.text = "Difficulty: " + difficulty;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
