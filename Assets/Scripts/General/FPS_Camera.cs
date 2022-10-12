using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera : MonoBehaviour {

    public GameObject player;

    public Camera cameraFPS;

    public float posX;//variable para ajustar bien la posicion x de la cámara
    public float posY;//variable para ajustar bien la altura de la cámara
    public float posZ;

    public float horizontalSpeed;
    public float verticalSpeed;

    float h;
    float v;

    public float maxViewAngle;
    public float minViewAngle;

    // Use this for initialization
    void Start () {

        transform.position = player.transform.position + new Vector3(posX, posY, posZ);
		
	}
	
	// Update is called once per frame
	void Update () {

        h = Input.GetAxis("Mouse X") * horizontalSpeed;
        v = Input.GetAxis("Mouse Y") * verticalSpeed;

        //Limite mirar izquierda y derecha
        if (transform.localEulerAngles.x > maxViewAngle && transform.localEulerAngles.x < 180f)
        {
            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, maxViewAngle, transform.localEulerAngles.z);
        }

        if (transform.localEulerAngles.x < (360 + minViewAngle) && transform.localEulerAngles.x > 180f)
        {
            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, (360 + minViewAngle),transform.localEulerAngles.z);
        }

        //Limite mirar arriba y abajo
        if (cameraFPS.transform.localEulerAngles.x > maxViewAngle && cameraFPS.transform.localEulerAngles.x < 180f)
        {
            cameraFPS.transform.rotation = Quaternion.Euler(maxViewAngle, cameraFPS.transform.localEulerAngles.y, cameraFPS.transform.localEulerAngles.z);
        }

        if (cameraFPS.transform.localEulerAngles.x < (360 + minViewAngle) && cameraFPS.transform.localEulerAngles.x > 180f)
        {
            cameraFPS.transform.rotation = Quaternion.Euler((360 + minViewAngle), cameraFPS.transform.localEulerAngles.y, cameraFPS.transform.localEulerAngles.z);
        }

        transform.Rotate(0, h, 0);
        cameraFPS.transform.Rotate(v, 0, 0);
        /*
        float xAngle = transformFPS.eulerAngles.x;
        float yAngle = transformFPS.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0f);
        */
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Rotación X: " + cameraFPS.transform.rotation.x + " Rotación Y: " + cameraFPS.transform.rotation.y);
            Debug.Log("Rotación X: " + cameraFPS.transform.localRotation.x + " Rotación Y: " + cameraFPS.transform.localRotation.y);
            Debug.Log("Rotación X: " + cameraFPS.transform.localEulerAngles.x + " Rotación Y: " + cameraFPS.transform.localEulerAngles.y);
            //Debug.Log("Rotación X: " + h + " Rotación Y: " + v);
            //Debug.Log("Rotación Quaternion: " + rotation);
            //  Debug.Log("angulo x: " + xAngle + " Angulo y: " + yAngle);
        }
        
    }
}
