using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemManager : ScriptableObject
{
    new public string name = "New Item";

    //Object icon into the Inventory
    public Texture icon = null;

    //Object category
    public string type = "";

    //Stats value change
    public int hpHeal = 0;
   
    public int addMaxHealth = 0;

    public bool isDefaultItem = false;
    public string description = "";


    //public int minQuantity = 0;
    public int maxQuantity = 0;

    public int quantity = 0;

    public int stackQuantity = 0;

    public int quantityInInventory = 0;
    public GameObject itemPrefab;

    public InventorySlot slot;

    //Resets the value of the items in the inventory at the start of the application
    private void OnEnable()
    {
        quantityInInventory = 0;
        stackQuantity = 0;

        Debug.Log("Enable");
    }

    /*
    //Using the item from the inventory
    public virtual void Use()
    {

        //PlayerStats player = FindObjectOfType<PlayerStats>();

        
        player.currentHealth += hpHeal;


        //player.maxHealth += addMaxHealth;
        

        stackQuantity-= 1;



        Debug.Log("Using item: " + Inventory.instance.itemQuantity);

        if (stackQuantity== 0)
        {
            //removing item from inventory
            RemoveFromInventory();

            Debug.Log("no more potions");
        }

        



        Debug.Log("Using " + name);
    }*/

    public void RemoveFromInventory()
    {



        Inventory.instance.DeleteItem(this);

    }

   

    public string DefineHeader()
    {
        string header = type;
        return header;
    }

    public string DefineContent()
    {
        string content = description;
        return content;
    }
    
}
