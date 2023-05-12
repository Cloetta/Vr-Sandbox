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
            //item.SetActive(objectName == item.name);

            Debug.Log("it is looping");

            if(objectName == item.name)
            {

                Instantiate(item, transform.position, Quaternion.identity);
            }

            
            
        }

        
    }
}
