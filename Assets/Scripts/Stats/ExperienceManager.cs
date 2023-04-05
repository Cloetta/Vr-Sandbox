using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{


    [SerializeField]
    float expPoints = 0f;

    //Event to update the level when exp points are enough for next level
    public event Action onExpReceived;


    public void GainedExp(float exp)
    {
        expPoints += exp;
        //Trigger action when getting experience
        onExpReceived();
    }

    public float GetPoints()
    {
        return expPoints;
    }
}
