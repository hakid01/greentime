using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject[] arrayItem = new GameObject[7];

    public Vector3[] startPosition = new Vector3[7];

    public GameObject prefabItem;

    bool stop;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < arrayItem.Length; i++)
        {
            Debug.Log("Instanciamos Item" + i);
            arrayItem[i] = Instantiate(prefabItem, startPosition[i], Quaternion.Euler(0f, 0f, 0f));
        }

        stop = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Timer.tiempoAgotado == true)
        {
            if(ContadorVidas.currentLife > 0 && stop == false)
            {
                Debug.Log("Empieza corrutina para volver a instanciar los items verdes");
                StartCoroutine(Restart());
                stop = true;//variable de control para que solo se inicie una vez la corrutina
            }
        }
		
	}

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(TiempoMensaje.tMensajeReiniciando);
        for (int i = 0; i < arrayItem.Length; i++)
        {
            Destroy(arrayItem[i].gameObject);
            arrayItem[i] = Instantiate(prefabItem, startPosition[i], Quaternion.Euler(0f, 0f, 0f));
            stop = false;
            /*
            if (arrayItem[i] == null)
            {
                Debug.Log("Instanciamos Item" + i);
                Instantiate(arrayItem[i], startPosition[i], Quaternion.Euler(0f, 0f, 0f));
            }
            */
        }
    }
}
