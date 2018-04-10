using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAnimation : MonoBehaviour {

    public Animation anim;
    public bool play;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        if (play == true)
        {
            play = false;
            anim.Play(anim.clip.name);
        }
	}
}
