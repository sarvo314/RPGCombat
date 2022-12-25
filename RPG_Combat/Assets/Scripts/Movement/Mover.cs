using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{

    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;
        NavMeshAgent player;
    
        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<NavMeshAgent>();   
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            //to convert into local velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
        public void MoveTo(Vector3 destination)
        {
            player.SetDestination(destination);
        }
    }
}

