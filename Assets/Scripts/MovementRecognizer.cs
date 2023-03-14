using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using PDollarGestureRecognizer;
using System.IO;
using UnityEngine.Events;


//Continue from this tutorial https://www.youtube.com/watch?v=kfA_73npjMA

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    public Transform movementSource;

    public float newPositionThresholdDistance = 0.05f;

    //it could be an idea to remove the mesh and recognise only empty object position for the shape
    public GameObject testCubePrefab;

    //gives the object a trail
    public GameObject trail;

    public bool creationMode = true; //if we are trying to create a new gesture or not
    public string newGestureName;

    public float recognitionThreshold = 0.9f;

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> { }
    public UnityStringEvent OnRecognised;


    private List<Gesture> trainingSet = new List<Gesture>();

    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();


    GameObject trailInstance;



    // Start is called before the first frame update
    void Start()
    {

        //uncomment when not on uni pcs

        /*string[] gestureFiles = Directory.GetFiles(Application.persistentDataPath, "*.xml");

        foreach (var item in gestureFiles)
        {
            trainingSet.Add(GestureIO.ReadGestureFromFile(item));
        }*/

        trailInstance = null;
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
            trailInstance = Instantiate(trail, movementSource.position, Quaternion.identity);
        }
        
    }

    void EndMovement()
    {
        Debug.Log("End Movement");
        isMoving = false;

        //Create the gesture from the position list
        Point[] pointArray = new Point[positionsList.Count];

        for (int i = 0; i < positionsList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionsList[i]);
            pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);

        }

        Gesture newGesture = new Gesture(pointArray);

        //Add a new gesture to the training set
        if(creationMode)
        {
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);

            //https://www.youtube.com/watch?v=kfA_73npjMA 10.29
            //storing element in a file to be able to retrieve it on each play session
            
            //uncomment when not on uni pcs
            /*string fileName = Application.persistentDataPath + "/" + newGesture.Name + ".xml";
            GestureIO.WriteGesture(pointArray, newGestureName, fileName);*/
        }
        //recognise the gesture
        else
        {
            Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
            Debug.Log(result.GestureClass + result.Score);
            
            //We can associate any function to the list in the inspector and they are going to trigger on recognition
            if(result.Score > recognitionThreshold)
            {
                OnRecognised.Invoke(result.GestureClass);
            }
        }

    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
        //getting last position
        Vector3 lastPosition = positionsList[positionsList.Count - 1];

        trailInstance.transform.position = movementSource.position;
        

        if(Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);
            if (testCubePrefab)
            {
                Destroy(Instantiate(testCubePrefab, movementSource.position, Quaternion.identity), 3);

                //testing if i can drag the object after spawned
                //testCubePrefab.transform.position = movementSource.position; //not working
            }
        }

        
        
    }
}
