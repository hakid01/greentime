using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraLookAt : MonoBehaviour {

    public Transform target;

    public Vector3 offset;
    public bool useOffsetValues;

    public float rotSpeed;

    public Transform pivot;

    // Use this for initialization
    void Start ()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;

    }
	
	// Update is called once per frame
	void Update ()
    {
        pivot.transform.position = target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * rotSpeed;
        pivot.Rotate(0, horizontal, 0);

        /*
        float vertical = Input.GetAxis("Mouse Y") * rotSpeed;
        pivot.Rotate(vertical, 0, 0);
        */
        float yAngle = pivot.eulerAngles.y;//hacemos interactuar el pivote solo, despues apuntaremos el player segun esto
        float xAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = target.position - (rotation * offset);

        transform.LookAt(target);

        transform.LookAt(target);
    }
}
