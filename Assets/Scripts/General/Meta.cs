using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour {

    static GameObject metaGO;

	// Use this for initialization
	void Start () {
        metaGO = GameObject.FindGameObjectWithTag("Meta");
        metaGO.SetActive(false);
	}

    public static void showMeta()
    { 
        metaGO.SetActive(true);
    }
}