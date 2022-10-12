using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Camera : MonoBehaviour {

    public GameObject player;

    public float posX;//variable para ajustar bien la posicion x de la cámara
    public float posY;//variable para ajustar bien la altura de la cámara
    public float posZ;

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject pivote;

	// Use this for initialization
	void Start () {

        pivote = this.transform.parent.gameObject;
        pivote.transform.position = player.transform.position + new Vector3(posX, posY, posZ);

    }
	
	// Update is called once per frame
	void Update () {

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook.y = Mathf.Clamp(mouseLook.y, -60f, 60f);// Restringir rotación vertical entre -60 y 60 grados.
        mouseLook.x = Mathf.Clamp(mouseLook.x, -60f, 60f);// Restringir rotación horizontal entre -60 y 60 grados.
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        pivote.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, pivote.transform.up);

    }
}
