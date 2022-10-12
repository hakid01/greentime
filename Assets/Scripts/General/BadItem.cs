using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItem : MonoBehaviour {

    public GameObject badItemEffect;

    public static bool colision;

    public static int extraTime;
    public int valueExtraTime;

    public static bool[] arrayDestroyed = new bool[3];

    // Use this for initialization
    void Start ()
    {
        extraTime = valueExtraTime;
        colision = false;

        for (int i = 0; i < arrayDestroyed.Length; i++)
        {
                arrayDestroyed[i] = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colision = true;
            Destroy(gameObject);
            //  CanvasExtraTime.extraTime = "- 10s";// prueba para ver si funciona el canvas
            Debug.Log("colision con: " + gameObject.tag);
            Instantiate(badItemEffect, transform.position, transform.rotation);
            Timer.UpdateTime(extraTime);

            if (gameObject.tag == "BadItem0")
            {
                arrayDestroyed[0] = true;
            }
            if (gameObject.tag == "BadItem1")
            {
                arrayDestroyed[1] = true;
            }
            if (gameObject.tag == "BadItem2")
            {
                arrayDestroyed[2] = true;
            }
        }
    }
}
