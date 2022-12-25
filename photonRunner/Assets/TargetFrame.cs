using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magnimus
{
    public class TargetFrame : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Application.targetFrameRate = 100;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(1 / Time.deltaTime);
        }
    }
}
