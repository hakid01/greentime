using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasExtraTime : MonoBehaviour {

    public static string extraTime;
    public Text canvasTxtExtraTime;

    public float tMensaje;

    private void Start()
    {
        //canvasTxtExtraTime = GameObject.FindGameObjectWithTag("extraTime").GetComponent<Text>();
        extraTime = "";
        canvasTxtExtraTime.text = extraTime;
       // canvasTxtExtraTime.transform.eulerAngles = Camera.main.transform.eulerAngles;
    }

    private void Update()
    {
        if (BadItem.colision == true)
        {
            StartCoroutine(TempBadItem());
        }
        if (Item.colision == true)
        {
            StartCoroutine(TempItem());
        }

    }

    IEnumerator TempBadItem()
    {
        BadItem.colision = false;
        Item.colision = false;
        canvasTxtExtraTime.color = Color.red;
        canvasTxtExtraTime.text = "" + BadItem.extraTime + "s";
        yield return new WaitForSeconds(tMensaje);
        canvasTxtExtraTime.text = null;
    }

    IEnumerator TempItem()
    {
        BadItem.colision = false;
        Item.colision = false;
        canvasTxtExtraTime.color = Color.green;
        canvasTxtExtraTime.text = "+" + Item.extraTime + "s";
        yield return new WaitForSeconds(tMensaje);
        canvasTxtExtraTime.text = null;
    }
}
