using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    public GameObject inventoryUI;
    //private MouseMove mouseMove;


    public InventorySlot[] slots;

    [SerializeField] Inventory inventory;

    public bool inventoryOn = false;

    void Start()
    {
        inventory = Inventory.instance;

        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        UpdateUI();

        inventoryUI.SetActive(false);

    }


    void Update()
    {
       


    }

    //Updates UI with the items collected and added into the List
    public void UpdateUI()
    {
        Debug.Log("updating ui");

        for (int index = 0; index < slots.Length; index++)
        {


            if (index < inventory.items.Count)
            {

                slots[index].AddToInventory(inventory.items[index]);
                //slots[index].quantityTxt.text = inventory.items[index].stackQuantity.ToString();
                slots[index].quantityTxt.text = slots[index].currentQuantity.ToString();

                Debug.Log(slots[index].quantityTxt.text);

            }
            else
            {
                slots[index].ClearSlot();
            }
        }


    }


    /*
    public void InventoryOnOff()
    {
        if (inventoryOn == false)
        {
            inventoryUI.SetActive(true);
            //playerScript.enabled = false;


            //mouseMove.enabled = false;
            Time.timeScale = 0f; //Game is paused while the inventory is open
            inventoryOn = true;

        }
        else
        {
            inventoryUI.SetActive(false);
            //playerScript.enabled = true;

            //playerRigidbody.constraints = RigidbodyConstraints.None;
            //mouseMove.enabled = true;
            Time.timeScale = 1f;
            inventoryOn = false;


        }
    }*/



}
