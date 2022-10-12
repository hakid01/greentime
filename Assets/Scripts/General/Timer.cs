using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public static float startTime; //contador de tiempo total transcurrido en segundos
    public static float currentTime;

    public int startTimeValue;
    public static int addedTime;
	Text timeRound;
    public static Text extraTime;
    int timeSec, timeMin;
    //float timeHour;

    public static float totalTime;

    public static bool tiempoAgotado;

    private void Awake()
    {
        extraTime = GameObject.FindGameObjectWithTag("extraTime").GetComponent<Text>();
        timeRound = GameObject.FindGameObjectWithTag("timeRound").GetComponent<Text>();
        startTime = startTimeValue;
        currentTime = startTime;
        totalTime = currentTime;
        tiempoAgotado = false;
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("tiempoAgotado: " + tiempoAgotado);
        }
        // SI EL JUEGO ESTÁ ACABADO NO CORRE EL TIEMPO
        if (ContadorVidas.currentLife <= 0)
        {
            timeRound.color = Color.red;
            return;
        }
            if (NextLevel.activate)
        {
            timeRound.color = Color.green;
            return;
        }
        timeRound.color = Color.white;
        //CRONOMETRO
        if (tiempoAgotado == false)
        {
            if (totalTime > 0)
            {
                currentTime -= Time.deltaTime;
                totalTime = currentTime + addedTime;
            }
            else if (totalTime < 0)
            {
                ContadorVidas.UpdateLife(1);
                tiempoAgotado = true;
                totalTime = 0;
                if (ContadorVidas.currentLife >0)
                {
                    StartCoroutine(ReiniciarValores());
                }
                else return;
            }
            else
            {
                tiempoAgotado = true;
                return;
            }
        }
        else return;

        timeSec = (int)totalTime % 60;
        timeMin = (int)(totalTime / 60) % 60;
        // timeHour = (totalTime / 3600) % 24;


        // Mostrar en pantalla variable timeRound como texto
        //timeRound.text = " Tiempo: " + timeMin.ToString ("f0") + ":" + timeSec.ToString ("f0") ;

        // string timerString = string.Format("{0:0}:{1:00}:{2:00}", timeHour, timeMin, timeSec); // timer con horas minutos y segundos
        string timerString = string.Format("{0:00}:{1:00}", timeMin, timeSec);
        timeRound.text = "Tiempo: " + timerString;
        
    }
    /*
    private void LateUpdate()
    {
        if (ContadorVidas.gameOver == true)
        {
            return;
        }
        else StartCoroutine(ReiniciarValores());
    }
    */
    public static void UpdateTime(int addTime)
    {
        addedTime += addTime;
        
        if (addTime >= 0)
        {
            extraTime.text = "+" + addTime + "s";
        }
        else
        {
            extraTime.text = "" + addTime + "s";
        }
       
    }

    IEnumerator ReiniciarValores()
    {
        yield return new WaitForSeconds(TiempoMensaje.tMensajeReiniciando);
        currentTime = startTime;
        totalTime = currentTime;
        addedTime = 0;
        tiempoAgotado = false;
        
    }
}
