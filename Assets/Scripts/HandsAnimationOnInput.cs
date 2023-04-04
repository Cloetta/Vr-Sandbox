using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class HandsAnimationOnInput : MonoBehaviour
{

    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;

    public XRNode inputSource;
    public InputHelpers.Button trigger;
    public InputHelpers.Button grip;



    public Animator handAnimator;

    void Start()
    {

    }

    void Update()
    {
        //float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        //this is working, but gets only 0 or 1
        InputHelpers.TryReadSingleValue(InputDevices.GetDeviceAtXRNode(inputSource), trigger, out float triggerValue);

        InputHelpers.TryReadSingleValue(InputDevices.GetDeviceAtXRNode(inputSource), grip, out float gripValue);

        //float gripValue = gripAnimationAction.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", triggerValue);
        Debug.Log(triggerValue);
        handAnimator.SetFloat("Grip", gripValue);
        Debug.Log(gripValue);
    }
}
