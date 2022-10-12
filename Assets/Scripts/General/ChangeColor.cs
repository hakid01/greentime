using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public Color startColor;
    public Color endColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        float t = (Timer.totalTime / Timer.startTime);
        if (t > 1) t = 1;
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
    }
}
