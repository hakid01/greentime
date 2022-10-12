using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItemGenerator : MonoBehaviour {

   // public Animator anim;

    public GameObject[] arrayItemMalo = new GameObject[3];

   // Vector3 startPosition = new Vector3(6f, 5f, 0f);

   // Quaternion startRotation = new Quaternion();

    public float[] inicialValue = new float[3];
    float[] restartTime = new float[3];

    // Use this for initialization
    void Awake () {

        //  anim = GetComponent<Animator>();
        Debug.Log("longitud array: " + arrayItemMalo.Length);
        //Instanciamos los item rojos que queremos en la escena
        //la posición del item se carga automaticamente al cargarse la animación que tiene por defecto
        for (int i = 0; i < arrayItemMalo.Length; i++)
        {
            Debug.Log("Instanciamos ItemMalo" + i);
            Instantiate(arrayItemMalo[i]);
            restartTime[i] = inicialValue[i];
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < arrayItemMalo.Length; i++)
        {
            if (BadItem.arrayDestroyed[i] == true)
            {
                if (i == 0) Invoke("ReloadItem0", restartTime[0]);
                if (i == 1) Invoke("ReloadItem1", restartTime[1]);
                if (i == 2) Invoke("ReloadItem2", restartTime[2]);
                BadItem.arrayDestroyed[i] = false;
            }
        }		
	}
    void ReloadItem0()
    {
        Instantiate(arrayItemMalo[0]);
    }
    void ReloadItem1()
    {
        Instantiate(arrayItemMalo[1]);
    }
    void ReloadItem2()
    {
        Instantiate(arrayItemMalo[2]);
    } 
}
