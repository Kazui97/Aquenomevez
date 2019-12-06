using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private CharacterController controller;
    public static Vector3 pos;
    public float speed;
    public float force = 0.0f;
    public bool  canjump = false;

    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();  
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if(Input.GetKey("w"))
        {
            transform.position+=transform.forward *(speed/20);
            animator.SetFloat("corre", controller.velocity.magnitude);
        } 

        if(Input.GetKey("s")) transform.position-=transform.forward*(speed/20);
        if(Input.GetKey("a")) transform.position-=transform.right*(speed/20);
        if(Input.GetKey("d")) transform.position+=transform.right*(speed/20);
        if (Input.GetMouseButtonDown(0)){
            animator.GetBool("ataque");
        }
       
    }

}
