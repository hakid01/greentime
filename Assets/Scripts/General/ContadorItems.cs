using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorItems : MonoBehaviour {

    public static int startItems;
    public int valueStartItems;
    static int leftItems;
    static Text contItems;

    public static Image ItemsRecogidos;

    bool startedCoroutine;

    // Use this for initialization
    void Awake()
    {
        ItemsRecogidos = GameObject.FindGameObjectWithTag("ItemsRecogidos").GetComponent<Image>();
        contItems = GameObject.FindGameObjectWithTag("contItems").GetComponent<Text>();

        startItems = valueStartItems;
        leftItems = startItems;
        //UpdateItems(-startItems);
        contItems.text = " Items: " + leftItems;

        ItemsRecogidos.fillAmount = 0;

        startedCoroutine = false;
    }

    private void Update()
    {
        if (ContadorVidas.currentLife <= 0)
        {
            contItems.color = Color.red;
            return;
        }
        else
        {
            if(Timer.tiempoAgotado == true)
            {
                if (startedCoroutine == false)
                {
                    StartCoroutine(Restart());
                    startedCoroutine = true;
                }
            }
            contItems.color = Color.white;
            if (leftItems == 0)
            {
                Meta.showMeta();
            }
        }
    }

    public static void UpdateItems(int lessItem)
    {
        leftItems -= lessItem;
        contItems.text = " Items: " + leftItems;
        ItemsRecogidos.fillAmount = ((float)startItems - (float)leftItems) / (float)startItems;
        Debug.Log("startItems: " + startItems + " leftItems: " + leftItems + " I.fillAmount: " + ItemsRecogidos.fillAmount);
    }
    
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(TiempoMensaje.tMensajeReiniciando);
        leftItems = startItems;
        UpdateItems(0);
        startedCoroutine = false;
    }
    
}
