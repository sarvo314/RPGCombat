using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField]
        float weaponRange = 2f;

        Transform target;
        private void Update()
        {
            //Debug.Log($"distance b/w transform and target is {Vector3.Distance(transform.position, target.position)}, ie is in range - {isInRange}, target is nu;; {target == null}");
            //Debug.Log($"We are moving {target != null} && {!isInRange}");

            //if (target != null)
            //{
            //bool isInRange = GetIsInRange();
            if (target == null) return;
            if (target != null && !GetIsInRange())
            {
                //    //target = null;
                GetComponent<Mover>().MoveTo(target.position);
                //    //target = null;
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
            //if (!isInRange && target == null)
            //{
            //    GetComponent<Mover>().MoveTo(target.position);

            //}
            //if (isInRange && target != null)
            //{
            //}
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            Debug.Log("Hit " + combatTarget);
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }
        public void Cancel()
        {
            target = null;
        }
    }

}