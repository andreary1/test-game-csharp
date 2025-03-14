using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    public int totalWood;
    public int carrots;
    public float currentWater;
    public int fishes;

    [Header("Limits")]
    public float waterLimit = 50;
    public float woodLimit = 20;
    public float carrotsLimit = 20;
    public float fishesLimit = 20f;

    public void WaterLimit(float water)
    {
        if (currentWater <= waterLimit)
        {
            currentWater += water;
        }

    }

}