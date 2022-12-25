using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StartMediapipeCamera : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void cameraStop();

    [DllImport("__Internal")]
    private static extern void cameraStart();

    [DllImport("__Internal")]
    private static extern string getActivity();

    [DllImport("__Internal")]
    private static extern string getCurrentMediapipeImage();

    private void Awake()
    {
        cameraStart();
    }
}
