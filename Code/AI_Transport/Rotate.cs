using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float Period;
    public float Radius;
    private float Rad = Mathf.PI * 2;
    private float CornerSpeed;
    private float X = 0.0f;
    private float Y = 0.0f;
    private float Z = 0.0f;

    void Update()
    {
        CornerSpeed = (Rad / Period) * Time.time;

        X = Mathf.Cos(CornerSpeed) * Radius;
        Z = Mathf.Sin(CornerSpeed) * Radius;

        transform.Translate(new Vector3(X, Y, Z) * Time.deltaTime);
    }
}
