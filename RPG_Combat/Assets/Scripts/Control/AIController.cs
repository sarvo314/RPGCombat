using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        float chaseDistance = 5f;

        private void Update()
        {
            //DistanceToPlayer();
            if (DistanceToPlayer() < chaseDistance)
            {
                print(gameObject.name + "should chase");
            }

        }

        private float DistanceToPlayer()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            return Vector3.Distance(player.transform.position, transform.position);
        }
    }

}