using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    public GameObject cameraTP;
    public GameObject cameraFP;

    public static bool isFPS;

    public GameObject canvasPlayer;

	// Use this for initialization
	void Start () {

        if (cameraTP.activeSelf == false && cameraFP.activeSelf == false)
        {
            cameraTP.SetActive(true);
        }
        if (cameraTP.activeSelf == false && cameraFP.activeSelf == true)
        {
            cameraTP.SetActive(true);
            cameraFP.SetActive(false);
        }
        isFPS = false;
        if (canvasPlayer != null)
        {
            if (canvasPlayer.activeSelf == false) canvasPlayer.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            isFPS = true;
            cameraTP.SetActive(false);
            cameraFP.SetActive(true);
            canvasPlayer.SetActive(false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            cameraTP.SetActive(true);
            cameraFP.SetActive(false);
            isFPS = false;
            canvasPlayer.SetActive(true);
        }
    }
}
