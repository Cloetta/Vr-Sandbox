using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    //Deleting this maybe?


    void Start()
    {
        List<InputDevice> devices = new List<InputDevice> ();
        InputDevices.GetDevices (devices);

        foreach (var item in devices)
        {
            Debug.Log (item.name + item.characteristics);
        }
        
    }

    void Update()
    {
        
    }
}
