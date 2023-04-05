using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;


    void Update()
    {
        //Activate the rays of the teleportation checking if the button is pressed
        leftTeleportation.SetActive(leftCancel.action.ReadValue<float>() == 0f && leftActivate.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(rightCancel.action.ReadValue<float>() == 0f && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
