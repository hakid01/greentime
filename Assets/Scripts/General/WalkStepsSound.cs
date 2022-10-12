using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStepsSound : MonoBehaviour {

    AudioSource pasos;

	// Use this for initialization
	void Start () {

        pasos = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision con: " + other.tag);
        if (other.tag == "Suelo")
        {
            Debug.Log("Paso!");
            pasos.Play();
        }
    }
}
