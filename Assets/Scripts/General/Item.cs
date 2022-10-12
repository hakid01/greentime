using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject itemEffect;
    public static int extraTime;
    public int valueExtraTime;

    public static bool colision;

    // Use this for initialization
    void Start () {

        extraTime = valueExtraTime;
        colision = false;
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colision = true;
            Debug.Log("colision");
            Instantiate(itemEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Timer.UpdateTime(extraTime);
            ContadorItems.UpdateItems(1);
        }
    }
}
