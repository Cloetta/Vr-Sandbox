using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objects;

    public void Spawn(string objectName)
    {
        foreach (var item in objects)
        {
            //replace this with instantiate and the "monster" object
            item.SetActive(objectName == item.name);

            //Doesn't activate 


            /*if (item.name == objectName)
            {
                item.SetActive(true);
                Debug.Log(item.name + " spawned");
            }
            else
            {
                Debug.Log("No match found.");
            }*/



            
        }
    }
}
