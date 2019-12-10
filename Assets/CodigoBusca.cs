using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CodigoBusca : MonoBehaviour
{
  [SerializeField]  private float sighRange = 0;
  [SerializeField]  private Transform PlayerTransform;
  private Transform _EnemyTransform;

   void Awake()
   {
       _EnemyTransform = transform;
   }

    void Start()
    {
        
    }


    void Update()
    {
        IsLookingThePlayer(PlayerTransform.position);
    }

    private bool IsLookingThePlayer(Vector3 playerposition)
    {
        var displacement = playerposition - _EnemyTransform.position;
        var distancetoplayer = displacement.magnitude;

        if(!(distancetoplayer <= sighRange)) return false;

        var dot = Vector3.Dot(_EnemyTransform.forward, displacement.normalized);

        if(!(dot >=0.65)) return false;

        var layermask = 1 << 2;

        layermask = -layermask;

        if(Physics.Raycast(_EnemyTransform.position + new Vector3(0,1.5f,0),displacement.normalized, out var hit, sighRange, layermask))
        {
            Debug.DrawRay(_EnemyTransform.position + new Vector3(0, 1.5f, 0), displacement.normalized * hit.distance, Color.red);
            Debug.Log("Did hit");


            if (hit.collider.GetComponent<prueba>())
            {
                Debug.DrawRay(_EnemyTransform.position + new Vector3(0, 1.5f, 0), displacement.normalized * hit.distance, Color.red);
                if(!hit.collider.GetComponent<prueba>())
                {
                    Debug.Log("yea");
                }
                return true;
            }
        }

    }
  
}
