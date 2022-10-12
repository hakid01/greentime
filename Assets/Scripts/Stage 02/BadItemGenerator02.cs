using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItemGenerator02 : MonoBehaviour {

    // public Animator anim;

    public GameObject[] arrayItemMalo = new GameObject[3];

    //public Vector3[] startPosition = new Vector3[3];

    public GameObject prefabItemMalo;

    public float[] inicialValue = new float[3];
    float[] restartTime = new float[3];

    public Animation anim;
    public AnimationClip[] badItemAnimClip = new AnimationClip[3];

    // Use this for initialization
    void Awake () {

        Debug.Log("longitud array: " + arrayItemMalo.Length);
        //Instanciamos los item rojos que queremos en la escena
        //la posición del item se carga automaticamente al cargarse la animación que tiene por defecto
        for (int i = 0; i < arrayItemMalo.Length; i++)
        {
            Debug.Log("Instanciamos ItemMalo" + i);
            //la posición (Vector3) y la rotación (Quaternion) no influyen al cargar directamente una animación
            arrayItemMalo[i] = Instantiate(prefabItemMalo, new Vector3 (10f, 10f, 10f), Quaternion.Euler(0f, 0f, 0f));
            arrayItemMalo[i].tag = "BadItem" + i;
            //Instantiate(arrayItemMalo[i]);
            restartTime[i] = inicialValue[i];
            anim = arrayItemMalo[i].AddComponent<Animation>();
            anim.AddClip(badItemAnimClip[i], "02BadItem0" + i);
            anim.Play("02BadItem0" + i);
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
        Debug.Log("Reinstanciando ItemRojo00");
        arrayItemMalo[0] = Instantiate(prefabItemMalo);
        arrayItemMalo[0].tag = "BadItem0";
        anim = arrayItemMalo[0].AddComponent<Animation>();
        anim.AddClip(badItemAnimClip[0], "02BadItem00");
        anim.Play("02BadItem00");
    }
    void ReloadItem1()
    {
        Debug.Log("Reinstanciando ItemRojo01");
        arrayItemMalo[1] = Instantiate(prefabItemMalo);
        arrayItemMalo[1].tag = "BadItem1";
        anim = arrayItemMalo[1].AddComponent<Animation>();
        anim.AddClip(badItemAnimClip[1], "02BadItem01");
        anim.Play("02BadItem01");
    }
    void ReloadItem2()
    {
        Debug.Log("Reinstanciando ItemRojo02");
        arrayItemMalo[2] = Instantiate(prefabItemMalo);
        arrayItemMalo[2].tag = "BadItem2";
        anim = arrayItemMalo[2].AddComponent<Animation>();
        anim.AddClip(badItemAnimClip[2], "02BadItem02");
        anim.Play("02BadItem02");
    } 
}
