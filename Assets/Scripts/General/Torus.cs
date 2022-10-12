using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus : MonoBehaviour {

    Transform _transform;
    Vector3 rotation = new Vector3(30, 80, 45);
    public float rotSpeed;

    // Use this for initialization
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Rotate(rotation,rotSpeed * Time.deltaTime);
    }
}
