using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] StartingStats player;


    public InputActionProperty testButton;

    // Update is called once per frame
    void Update()
    {
        if (testButton.action.WasPressedThisFrame())
        {
            /*if (player.CanUseSkill1())
            {
                Debug.Log("Using skill 1!");

            }
            else
            {
                Debug.Log("Nope!");
            }*/


            player.GetComponent<State>().currentHealth -= 1;
            player.GetComponent<State>().currentMana -= 1;


        }

        
    }
}
