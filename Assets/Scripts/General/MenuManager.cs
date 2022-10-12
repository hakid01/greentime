using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Animator anim;
    bool esVisible;

    //float retraso;
    int nivel;

    AudioSource audioSourceManager;
    // Use this for initialization
    void Start () {
        esVisible = false;

        audioSourceManager = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CargarNivel(int pNivel)
    {
        nivel = pNivel;// tomamos el valor introducido en unity con la función OnClick de los botones.
        StartCoroutine(Temp());//LLamamos a una corrutina para que se cargue el nivel desde que acabe el sonido del boton
    }
    // La corrutina no hace nada hasta  que pasa el tiempo del soindo (audioSourceManager.clip.length)
    IEnumerator Temp()
    {
        yield return new WaitForSeconds(audioSourceManager.clip.length);
        SceneManager.LoadScene(nivel);
    }

    public void MostrarNiveles()
    {
        if (!esVisible)
        {
            esVisible = true;
            PanelNiveles.esVisible = true;
        }
        else
        {
            esVisible = false;
            PanelNiveles.esVisible = false;
        }
    }

    public void Salir()
    {
        Application.Quit();
    }
}
