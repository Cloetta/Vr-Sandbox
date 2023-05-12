using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Inventory : MonoBehaviour
{
    //NOTE:
    //A singleton is a class that allows only a single instance of itself to be created and gives access to that created instance.
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of inventory found");
            Destroy(this.gameObject);
            return; //returning out of this method
        }
        instance = this;
        //SceneManager.LoadScene("Level1");
    }

    #endregion    

    //NOTE:
    //A Delegate is a reference pointer to a method. It allows us to treat method as a variable and pass method as a variable for a callback. When it get called , it notifies all methods that reference the delegate. The basic idea behind them is exactly the same as a subscription magazine. Anyone can subscribe to the service and they will receive the update at the right time automatically.
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int inventorySlots = 5;

    public List<ItemManager> items = new List<ItemManager>();

    public int itemQuantity;
    
    public InventorySlot [] slot;
    int slotIndex = 0;


    public bool AddItem (ItemManager item)
    {

        

        if (!item.isDefaultItem)
        {
            

            //Checking if the item picked up is of the same type of others in the inventory, looping through all slots
            foreach (ItemManager obj in items)
            {         
                if (obj.type == item.type)
                {

                    
                    if (slot[slotIndex].currentQuantity >= item.maxQuantity)
                    {
                        if (items.Count >= inventorySlots)
                        {
                            Debug.Log("Not enough room");
                            return false;
                        }
                        
                        //Move to the next slot
                        slotIndex++;

                        //Add items
                        items.Add(item);
                        
                        itemQuantity = item.quantity;

                        //Increasing the quantity of the items
                        slot[slotIndex].currentQuantity += itemQuantity;


                        /* ------- TEST -------

                        //slot[slotIndex].currentQuantity = +itemQuantity;

                        //int temp = slot[slotIndex].currentQuantity + itemQuantity;

                        int toFullStack = slot[slotIndex].currentQuantity - item.maxQuantity;

                        //temp += toFullStack;
                        slot[slotIndex].currentQuantity = item.maxQuantity;

                        //slot[slotIndex].currentQuantity = temp;
                        Debug.Log("slot index before:" + slotIndex);

                        slotIndex++;
                        items.Add(item);

                        //itemQuantity = item.quantity;
                        itemQuantity += toFullStack;

                        Debug.Log("slot index after:" + slotIndex);
                        //int newQuantity = temp - item.maxQuantity;
                        slot[slotIndex].currentQuantity = 0;
                        slot[slotIndex].currentQuantity += itemQuantity;*/

                        return true;

                    }
                    

                   
                    itemQuantity = item.quantity;
                    Debug.Log(itemQuantity);
                    

                    slot[slotIndex].currentQuantity += itemQuantity;
                    return true;


                }
               

                
            }
            

           //Checks if all the slots are occupied
            if (items.Count >= inventorySlots)
            {
                Debug.Log("Not enough room");
                return false;
            }



            
            items.Add(item);

            //itemQuantity = item.DefineQuantity();
            itemQuantity = item.quantity;
            //item.quantityInInventory += itemQuantity;

            slot[slotIndex].currentQuantity += itemQuantity;
            



            if (onItemChangedCallBack != null)
            {
                //Triggers the event created before
                onItemChangedCallBack.Invoke();
            }
        }

        
        return true;





    }

    public void DeleteItem (ItemManager item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
        {
            //Trigger the event we created before
            onItemChangedCallBack.Invoke();

        }
    }
}
