using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNiveles : MonoBehaviour {

    public Animator anim;
    public static bool esVisible;

	// Use this for initialization
	void Start () {

        esVisible = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) Debug.Log("PanelNiveles es visible: " + esVisible);
        if (!esVisible)
        {
            anim.SetBool("esVisible", false);
        }
        else anim.SetBool("esVisible", true);

    }
}
