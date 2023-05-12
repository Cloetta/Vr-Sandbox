using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public RawImage icon;
    
    ItemManager item;
    
    public TextMeshProUGUI quantityTxt;
    /*[SerializeField]
    Text descriptionHeader;
    [SerializeField]
    Text description;


    [SerializeField]
    GameObject descriptionWindow;
    [SerializeField]*/
    Inventory inventory;

    //public string header;
    //[Multiline()] //makes the text multiline
    //public string content;

    [SerializeField] GameObject prefabIcon;

    public int currentQuantity;
    

    //public int itemNum;

    public void AddToInventory(ItemManager newItem)
    {

        item = newItem;

        //header = item.DefineHeader();
        //content = item.DefineContent();
        //to test stackable objects
        //foreach (ItemManager obj in inventory.items)
        //{
        //    if (obj.itemTypes == item.itemTypes)
        //    {
        //        itemQuantity += item.quantity;
        //    }
        //}
        //testing stackable objects end
        if(icon == null)
        {
            RectTransform slotTransform = GetComponent<RectTransform>();
            Vector3 spawnLocation = new Vector3(slotTransform.localPosition.x, slotTransform.localPosition.y, slotTransform.localPosition.z);


            GameObject itemObject = Instantiate(prefabIcon, spawnLocation, Quaternion.identity);

            itemObject.transform.SetParent(slotTransform, false);

            itemObject.transform.localScale = Vector3.one;

            icon = itemObject.GetComponent<RawImage>();
            quantityTxt = itemObject.GetComponentInChildren<TextMeshProUGUI>();

            icon.texture = item.icon;
            icon.enabled = true;
            quantityTxt.enabled = true;
            //quantityTxt.text = item.quantityInInventory.ToString();

            //currentQuantity += item.quantity;

            quantityTxt.text = currentQuantity.ToString();
        }
       


    }

    public void ClearSlot()
    {
        item = null;

        if(icon != null)
        {
            icon.texture = null;
            icon.enabled = false;
        }

        if (quantityTxt != null)
        {
            quantityTxt.enabled = false;
        }
        
       
              
    }

    public void OnDeleteButton()
    {
        
        Inventory.instance.DeleteItem(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            currentQuantity -= 1;
            quantityTxt.text = currentQuantity.ToString();


            State playerheal = GameObject.FindGameObjectWithTag("Player").GetComponent<State>();

            playerheal.currentHealth += item.hpHeal;

            //Validation condition: current health doesn't go over the maximum
            if (playerheal.currentHealth > playerheal.maxHealth)
            {
                playerheal.currentHealth = playerheal.maxHealth;    
            }


            if (currentQuantity == 0)
            {
                item.RemoveFromInventory();
            }
           
        }
        else if (item == null)
        {
            Debug.Log("The slot is empty");
            return;
        }
    }

    //Discard items and place them back into the world
    public void DiscardItem()
    {
        

        if (item != null)
        {
            currentQuantity -= 1;
            quantityTxt.text = currentQuantity.ToString();


            GameObject player = GameObject.FindGameObjectWithTag("Player");

            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y+1, player.transform.position.z+2);


            Instantiate(item.itemPrefab, position, Quaternion.identity);

            if (currentQuantity == 0)
            {
                item.RemoveFromInventory();
            }

        }
        else if (item == null)
        {
            Debug.Log("The slot is empty");
            return;
        }

        

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            /* (draggableItem.parentAfterDrag.CompareTag("Drop"))
            {
                DiscardItem();
                Destroy(dropped);


            }*/
        }


        
        
    }

    /*public void Description()
    {

        if (descriptionWindow.active == true)
        {
            descriptionWindow.SetActive(false);
        }
        else
        {
            descriptionWindow.SetActive(true);

            descriptionHeader.text = item.type;
            description.text = item.description;
        }
        



    }*/



    //Tooltip trigger

    /*public void OnPointerEnter(PointerEventData eventData)
    {

        TooltipSystem.Show(content, header);
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }*/
}


