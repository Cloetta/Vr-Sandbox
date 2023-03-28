using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class AnimateHandOnInput : MonoBehaviour
{

    public InputActionProperty pinchAnimationAction;


    public XRNode inputSource;
    public InputHelpers.Button inputButton;

    public Animator handAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        //this is working, but gets only 0 or 1
        //InputHelpers.TryReadSingleValue(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out float triggerValue);  

        handAnimator.SetFloat("Trigger", triggerValue);
        Debug.Log(triggerValue); 
    }
}
