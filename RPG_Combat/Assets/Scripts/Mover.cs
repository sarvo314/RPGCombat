using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent player;
    Ray ray;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        Debug.DrawRay(ray.origin, ray.direction * 100);
        player.SetDestination(target.transform.position);
    }
}
