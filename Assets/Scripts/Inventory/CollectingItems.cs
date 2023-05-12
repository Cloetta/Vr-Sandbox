using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingItems: MonoBehaviour
{
    public bool canPickup = false;

    public ItemManager item;

    [SerializeField]
    InventoryUI inventory;


    private void Start()
    {
        if(inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryUI>();
        }
        
    }

    void Update()
    {
        /*if (canPickup == true && Input.GetKeyDown(KeyCode.F))
        {
           
            
            PickUpItem();

            //Possible implementation: text appears on screen? On hover on the item to inform the player of the item stats/skills effects?
        }
        else if (canPickup == Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Not in range");
            return;
            
            //Nothing happens
        }*/
    }

    //Check collision with the player to determine if we can interact with the item or not
    /*private void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.tag == "Player")
        {
            canPickup = true;          
        }
    }

    //Check collision with the player to determine if we can interact with the item or not
    private void OnTriggerExit(Collider collidedObject)
   {
        if (collidedObject.tag == "Player")
        {
            canPickup = false;
        }
               
    }*/


    public void PickUpItem()
    {

        if (inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryUI>();
        }

        Debug.Log("Picked up: " + item.name);

        //Item is added to the inventory
        bool pickedUp = Inventory.instance.AddItem(item);
        
        if (pickedUp == true)
        {
            inventory.UpdateUI();
            //Object into the environment is destroyed
            Destroy(gameObject);
        }

    }
}
