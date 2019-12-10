using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] private float sighRange = 0;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private GameObject warning = null;
    [SerializeField] private GameObject detect = null;
    private Transform enemitransform;

    void Awake()
    {
        enemitransform = transform;
    }

    void Start()
    {
        
    }


    void Update()
    {
        IsLookinThePlayer(PlayerTransform.position);
    }

    private float timeOnsight;

    private void Detecplayer(bool IsLookinThePlayer)
    {
        warning.SetActive(true);
        detect.SetActive(false);
        if(timeOnsight<=3)
        {
            timeOnsight += Time.deltaTime;

            if (!(timeOnsight >= 3)) return;
            warning.SetActive(false);
            detect.SetActive(true);
            SceneManager.LoadScene("escenario1");
            
        }
       

        else
        {
            if(timeOnsight > 0)
            {
                timeOnsight -= Time.deltaTime;
            }
            if (!(timeOnsight <= 0)) return;
            warning.SetActive(false);
            detect.SetActive(false);
        }
        
    }

    private bool IsLookinThePlayer(Vector3 playerPosition)
    {
        var displacement = playerPosition - enemitransform.position;
        var distacetoPlayer = displacement.magnitude;
        if (distacetoPlayer <= sighRange)
        {
            var dot = Vector3.Dot(enemitransform.forward, displacement.normalized);
            if (!(dot >= 0.5)) return false;

            var layerMask = 1 << 2;

            layerMask = ~layerMask;

            if(Physics.Raycast(enemitransform.position,displacement.normalized,out var hit , sighRange, layerMask))
            {
                Debug.DrawRay(enemitransform.position, displacement.normalized * hit.distance, Color.red);

                Debug.Log("Did hit");

                if (!hit.collider.GetComponent<prueba>()) return false;

                Debug.DrawRay(enemitransform.position, displacement.normalized * hit.distance, Color.green);
                Debug.Log("yea");

               
            }
        }
        return false;
    }
    
}
