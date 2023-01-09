using System;
using RPG.Movement;
using UnityEngine;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Mover mover;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }

        // Update is called once per frame
        void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            Debug.Log("Cannot move");

        }

        private bool InteractWithCombat()
        {

            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();
                if (combatTarget == null) continue;
                Debug.Log("Interacted with combat");

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(combatTarget);
                }
                return true;
            }

            Debug.Log("Not interacted with combat");
            return false;
        }

        private bool InteractWithMovement()
        {

            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    //Debug.Log("We mofe");

                    mover.StartMoverAction(hit.point);
                }
                Debug.Log("Interacted with movement");

                return true;
            }
            Debug.Log("Not Interacted with movement");
            return false;
        }

        private static Ray GetMouseRay()
        {
            Ray lastRay;
            lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            return lastRay;
        }
    }
}

