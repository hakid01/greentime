using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAT : MonoBehaviour {

    public Transform target, pivot;
    public float rotSpeed;

    //private Vector3 relativePosition;

    public Vector3 offset;

    public bool useOffsetValues;

    public float maxViewAngle, minViewAngle;

    public bool invertY;

    public bool invertX;


    // Use this for initialization
    void Start () {
        
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        //Colocar el pivote de ayuda para rotar la camara en vertical, en la posición del target
        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;

        //Bloquear cursor en la pantalla de juego
        Cursor.lockState = CursorLockMode.Locked; 
	}
	
	// Update is called once per frame
	void LateUpdate () {

        pivot.transform.position = target.transform.position;

        //Tomar posicion en X del ratón para rotar el target(player)
        float horizontal = Input.GetAxis("Mouse X") * rotSpeed;
        //target.parent.Rotate(0, horizontal, 0); //Así rota directamente el player con la rotación de la cámara
        if (invertX)
        {
            pivot.Rotate(0, -horizontal, 0);// Así rota el pivote de la cámara, para después apuntar el player en esa dirección
        }
        else pivot.Rotate(0, horizontal, 0);// Así rota el pivote de la cámara, para después apuntar el player en esa dirección

        //Tomar posicion en Y del ratón para rotar el pivote
        float vertical = Input.GetAxis("Mouse Y") * rotSpeed;
        if (invertY)
        {
            pivot.Rotate(-vertical, 0, 0);
        }
        else pivot.Rotate(vertical, 0, 0);
        
        //Limite up/down rotación de la camara
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, pivot.rotation.eulerAngles.y, pivot.rotation.eulerAngles.z);
        }

        if (pivot.rotation.eulerAngles.x < (360 + minViewAngle) && pivot.rotation.eulerAngles.x > 180f)
        {
            pivot.rotation = Quaternion.Euler((360 + minViewAngle), pivot.rotation.eulerAngles.y, pivot.rotation.eulerAngles.z);
        }

        //Mover camara según rotación del target (horizontal) y pivot (vertical) y posición relativa inicial (relativePosition)
        //float yAngle = target.eulerAngles.y; //hacemos interactuar directamente al player
        float yAngle = pivot.eulerAngles.y;//hacemos interactuar el pivote solo, despues apuntaremos el player segun esto
        float xAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = target.position - (rotation * offset);
        
        if(transform.position.y < (target.position.y-0.5f))
        {
            transform.position = new Vector3(transform.position.x, (target.position.y - 0.5f), transform.position.z);
        }
        
        transform.LookAt(target);
    }
}
