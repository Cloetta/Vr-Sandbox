using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


//Continue from this tutorial https://www.youtube.com/watch?v=kfA_73npjMA

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    public Transform movementSource;

    public float newPositionThresholdDistance = 0.05f;
    public GameObject testCubePrefab;

    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);

        //Start movement
        if(!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending movement
        else if(isMoving && !isPressed)
        {
            EndMovement();
        }
        //Updating the movement
        else if(isMoving && isPressed)
        {
            UpdateMovement();
        }


    }


    void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
        //reset the position when a new movement starts
        positionsList.Clear();
        positionsList.Add(movementSource.position);

        //if we have a cube prefab assigned to the variable, then it will spawn and destroy itself after 3 seconds
        if (testCubePrefab)
        {
            Destroy(Instantiate(testCubePrefab, movementSource.position, Quaternion.identity), 3);
        }
        
    }

    void EndMovement()
    {
        Debug.Log("End Movement");
        isMoving = false;

    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
        //getting last position
        Vector3 lastPosition = positionsList[positionsList.Count - 1];

        if(Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);
            if (testCubePrefab)
            {
                Destroy(Instantiate(testCubePrefab, movementSource.position, Quaternion.identity), 3);
            }
        }
        
    }
}
