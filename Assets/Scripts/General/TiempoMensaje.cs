using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TiempoMensaje : MonoBehaviour {

	public float tMensaje;
    public float valueReinicio;
    public static float tMensajeReiniciando;
    public float valueTiempoMensajeGO;
    public static float tMensajeGameOver;

    static Text nameText;
    static Text nameText01;

    float tiempoRestante;
    int tiempoRestanteSegundos;

    bool startedCoroutine;

	// Use this for initialization
	void Start () {
        nameText = GameObject.FindGameObjectWithTag("nameText").GetComponent<Text>();
        nameText01 = GameObject.FindGameObjectWithTag("nameText01").GetComponent<Text>();
        StartCoroutine (Temp ());
        tMensajeReiniciando = valueReinicio;
        tiempoRestante = tMensajeReiniciando;

        tMensajeGameOver = valueTiempoMensajeGO;

        startedCoroutine = false;
	}
    
    private void Update()
    {
        if (Timer.tiempoAgotado == true)
        {
            tiempoRestante -= Time.deltaTime;
            tiempoRestanteSegundos = (int)tiempoRestante % 60;
            
            string timerString = string.Format("{0:00}", tiempoRestanteSegundos);
            
            if (ContadorVidas.currentLife > 0)
            {
                nameText.text = "Reiniciando en " + timerString + " segundos";//Aquí hacemos que se muestre el texto reiniciando
                if (startedCoroutine == false)
                {
                    nameText01.text = "Tiempo Agotado!!!";
                    StartCoroutine(Restart());
                    startedCoroutine = true;
                }
            }
            //else return;
            else
            {
                if (startedCoroutine == false)
                {
                    nameText.color = Color.red;
                    nameText.text = "HAS PERDIDO! Necesitas mejorar";
                    StartCoroutine(GameOver());
                    startedCoroutine = true;
                }
            }
        }   
    }

    //Corrutina para que aparezca el título/número de la fase/escena cargada
    IEnumerator Temp(){
		Scene scene = SceneManager.GetActiveScene ();
		nameText.text = "STG - " + scene.name;
		yield return new WaitForSeconds (tMensaje);
		nameText.text = null;
	}
    //Corrutina para que se muestre en pantalla el texto reinicianco despues de perder una vida durante solo un tiempo establecido (tMensajeReiniciando)
    IEnumerator Restart()
    {
       // string timerString = string.Format("{0:00}", tiempoRestanteSegundos);
       // nameText.text = "Reiniciando en " + timerString + " segundos";//Aquí hacemos que se muestre el texto reiniciando
        yield return new WaitForSeconds(tMensajeReiniciando);
        Timer.tiempoAgotado = false;
        nameText.text = null;
        nameText01.text = null;
        //REstauramos valores iniciales para que la siguiente vez que se agote el tiempo vuelva a aparecer el mensaje
        tMensajeReiniciando = valueReinicio;
        tiempoRestante = tMensajeReiniciando;
        startedCoroutine = false;
       // Debug.Log("tMensajeReiniciando: " + tMensajeReiniciando + " tiempoRestante: " + tiempoRestante + " Timer.tiempoAgotado: "+ Timer.tiempoAgotado);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(tMensajeGameOver);
        nameText.text = null;
        NewGAme.enableNewGame();

    }

}
	