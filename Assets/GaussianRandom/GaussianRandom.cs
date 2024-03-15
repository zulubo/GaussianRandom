using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomExtensions
{
    public static float GaussianRandom(float stdDev)
    {
        float u1 = Random.value;
        float u2 = Random.value;
        float randomStdNormal = Mathf.Sqrt(-2f * Mathf.Log(u1, 10)) * Mathf.Sin(2 * Mathf.PI * u2);
        return randomStdNormal * stdDev;
    }

    public static float GaussianRandomInRange(float stdDev, float range)
    {
        if(range < stdDev)
        {
            Debug.LogError("Range should be bigger than the standard deviation!");
        }

        float f;
        do
        {
            f = GaussianRandom(stdDev);
        } while (Mathf.Abs(f) > range);

        return f;
    }

    public static float LogNormalRandom(float mean, float stdDev)
    {
        return Mathf.Exp(GaussianRandom(stdDev)) * mean;
    }
}
