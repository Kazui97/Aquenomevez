using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    public static Vector3 pos;
    public float speed;
    public float force = 0.0f;
    public bool  canjump = false;
   
    private Animator animator;

    void Awake()
    {   
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        bool caminar;
        if (caminar = Input.GetKey(KeyCode.W))
        {
            animator.SetBool("caminar", caminar);
           // animator.SetFloat("caminarfloat", speed);
            transform.position+=transform.forward *(speed);
           
            
        }
        

        if(Input.GetKey("s")) 
        {
            animator.SetFloat("caminarfloat", speed);
            transform.position -= transform.forward * (speed / 20);
        }
        if(Input.GetKey("a")) transform.position-=transform.right*(speed/20);
        if(Input.GetKey("d")) transform.position+=transform.right*(speed/20);
        if (Input.GetKey(KeyCode.Space)){
            animator.SetTrigger("atacar");
        }
       
    }

}
