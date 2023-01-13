using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{

    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;

        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }
        public void Stop()
        {
            Debug.Log("We are stopped");
            navMeshAgent.isStopped = true;
        }

        public void StartMoverAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            //to convert into local velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
        public void MoveTo(Vector3 destination)
        {
            Debug.Log("We are moving from moveto");

            //navMeshAgent.SetDestination(destination);
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
    }
}

