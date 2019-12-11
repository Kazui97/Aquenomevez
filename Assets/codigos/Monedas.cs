using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    void Start()
    {
      
    }

     public void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.GetComponent<prueba>() )
        {
           
            Destroy(this.gameObject);
            
        }
    }
   
    void Update()
    {
        
    }
}
