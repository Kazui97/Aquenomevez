using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    public float movimiento = 5.0f;
    public float rotacion = 200.0f;
    private Animator ani;
    public float x, y;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime *rotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * movimiento);
        ani.SetFloat("velX", x);
        ani.SetFloat("velY", y);
    }
}
