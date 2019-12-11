using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class prueba : MonoBehaviour
{

    public float movimiento = 5.0f;
    public float rotacion = 200.0f;
    private Animator ani;
    public float x, y;
    public bool ataque;
    public int contadormoneda;
    public Text monedas;
    public ParticleSystem portal;
    public GameObject salida = null;
    public Text mens;
    public Text menfinal;
    
    void Start()
    {
        ani = GetComponent<Animator>();
        salida.SetActive(false);
        mens.enabled = (false);
        
    }


    public void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.tag == "moneda" )
        {
            contadormoneda++;
           Debug.Log("lol");

           if(contadormoneda >= 18)
           {
             // portal.Play();
                mens.enabled = (true);
                mens.text = "VE AL PORTAL :D ";
                Invoke("Mensaje",3);
               salida.SetActive(true);
           }
          
        }
        if(col.gameObject.tag == "salida")
           {
               Debug.Log("sali");
               SceneManager.LoadScene("escenario1");
                menfinal.text = "FIN DEL JUEGO ";
           }
    }
    
    
       
    
    void Mensaje()
    {
        mens.enabled = false;
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        ataque = Input.GetKey(KeyCode.F);
        transform.Rotate(0, x * Time.deltaTime *rotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * movimiento);
        ani.SetFloat("velX", x);
        ani.SetFloat("velY", y);
        ani.SetBool("ataque",ataque);
        monedas.text = "monedas " + contadormoneda;
        
    }
}
