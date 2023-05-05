using System;
using RPG.Movement;
using UnityEngine;
using RPG.Combat;

namespace RPG.Control
{
    [RequireComponent(typeof(Fighter))]
    public class PlayerController : MonoBehaviour
    {
        Mover mover;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }
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
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target != null)
                {
                    if (!GetComponent<Fighter>().CanAttack(target.gameObject))
                    {
                        continue;
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        GetComponent<Fighter>().Attack(target.gameObject);
                    }
                    return true;
                }

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

