using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

    //stores the range in which we are spawning players
    static float xValue = 48f;
    static float yValue = 4f;
    static float zValue = 48f;
    public static Vector3 GetRandowmSpawnPoint()
    {
        return new Vector3(Random.Range(-xValue, xValue), yValue, Random.Range(-zValue, zValue));
    }
}
