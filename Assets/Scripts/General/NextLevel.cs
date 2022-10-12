using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	
	public string levelToLoad;
    public float retraso;
    public static bool activate;

    Transform player;
    GameObject levelFinished;

    public AudioClip winSound;

    // Use this for initialization
    void Awake () {
        activate = false;
        levelFinished = GameObject.FindGameObjectWithTag("LevelFinished"); // Canvas
        if(levelFinished.activeSelf == true) levelFinished.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerAnimController.win)
        {
            winStage();
        }
	}

    void winStage()
    {
        enableLevelFinished();
        countdown();
        Debug.Log("retraso: " + retraso);
        if (retraso <= 0) SceneManager.LoadScene(levelToLoad);
    }

    void countdown()
    {
        if (retraso > 0) retraso -= Time.deltaTime;
    }

    void enableLevelFinished()
    {
        levelFinished.SetActive(true);
        activate = true;
    }
}

