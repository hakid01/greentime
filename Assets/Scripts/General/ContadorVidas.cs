using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContadorVidas : MonoBehaviour {

    public static int startLife;
    public int valueStartLife;
    public static int currentLife;
    static Text contVidas;

    public static bool gameOver;

    // Use this for initialization
    void Awake() {

        gameOver = false;

        contVidas = GameObject.FindGameObjectWithTag("contVidas").GetComponent<Text>();
        startLife = valueStartLife;
       // UpdateLife(-startLife);
        currentLife = startLife;
        contVidas.text = " Vidas: " + currentLife;
    }

    void Update()
    {
        if (currentLife <= 0)
        {
            Invoke("NewGame", TiempoMensaje.tMensajeGameOver); //NewGAme.enableNewGame();
            contVidas.color = Color.red;
            return;
        }
        contVidas.color = Color.white;
    }

    public static void UpdateLife(int lessLife)
    {
        currentLife -= lessLife;
        contVidas.text = " Vidas: " + currentLife;
    }
    void NewGame()
    {
        NewGAme.enableNewGame();
    }
}
