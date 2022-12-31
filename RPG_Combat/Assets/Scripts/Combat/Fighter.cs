using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField]
        float weaponRange = 2f;

        Transform target;
        private void Update()
        {
            bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
            //Debug.Log($"distance b/w transform and target is {Vector3.Distance(transform.position, target.position)}, ie is in range - {isInRange}, target is nu;; {target == null}");
            Debug.Log($"We are moving {target != null} && {!isInRange}");

            if (isInRange && target != null)
            {
                GetComponent<Mover>().Stop();
                target = null;
            }
            else
            {
                GetComponent<Mover>().MoveTo(target.position);
            }

            //if (target != null && isInRange)
            //{
            //    Debug.Log("we are moving");
            //    Debug.Log(target.position);
            //    GetComponent<Mover>().MoveTo(target.position);
            //    //target = null;
            //}
            //else
            //{
            //    GetComponent<Mover>().Stop();
            //}

        }

        public void Attack(CombatTarget combatTarget)
        {
            Debug.Log("Hit");
            target = combatTarget.transform;
        }
    }

}