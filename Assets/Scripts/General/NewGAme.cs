using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGAme : MonoBehaviour {

    public static GameObject newGame;
    public static bool finnished = false;

    void Awake() {
        newGame = GameObject.FindGameObjectWithTag("newGame"); // Canvas
        if (newGame.activeSelf == true) newGame.SetActive(false);
    }

    public static void disableNewGame() {
        newGame.SetActive(false);
        finnished = false;
    }

    public static void enableNewGame()
    {
        newGame.SetActive(true);
        finnished = true;
        // INICIAR UNA NUEVA PARTIDA
        if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Reiniciar Partida");
            SceneManager.LoadScene ("STAGE 01");
            disableNewGame();
        }
        // SALIR DEL JUEGO
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Application.Quit();
            Debug.Log("Salir");
        }
    }
}
