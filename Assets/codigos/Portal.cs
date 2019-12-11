using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static Portal instance;

    public int contadormonedas;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("error");
            return;
        }
        instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log(contadormonedas);
    }
}
