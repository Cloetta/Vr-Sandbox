using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{


    //make private later
    public float totalExpPoints = 0f;

    public float expThisLevel = 0f;

    //Event to update the level when exp points are enough for next level
    public event Action onExpReceived;


    public void GainedExp(float exp)
    {
        totalExpPoints += exp;
        //Trigger action when getting experience
        expThisLevel += exp;

        onExpReceived();
    }

    public float GetPoints()
    {
        return totalExpPoints;
    }


}
