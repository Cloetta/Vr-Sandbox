using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class HMDInfoManager : MonoBehaviour
{

    //don't need this anymore - delete

    void Start()
    {
        //Debug.Log("Is Device Active " + XRSettings.isDeviceActive);
        //Debug.Log("Device Name is : " + XRSettings.loadedDeviceName);

        if (!XRSettings.isDeviceActive)
        {
            Debug.Log("No Headset pugged");
        }
        else if(XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockHMDDisplay"))
        {
            Debug.Log("Using Mock HMD");
        }
        else
        {
            Debug.Log("Headset plugged in is: " + XRSettings.loadedDeviceName);
        }
    }

    void Update()
    {
        
    }
}
