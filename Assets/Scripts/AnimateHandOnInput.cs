using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AnimateHandOnInput : MonoBehaviour
{

    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;


    public Animator handAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        //this is working, but gets only 0 or 1
        //InputHelpers.TryReadSingleValue(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out float triggerValue);  

        float gripValue = gripAnimationAction.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", triggerValue);
        Debug.Log(triggerValue);
        handAnimator.SetFloat("Grip", gripValue);
        Debug.Log(gripValue);
    }
}
