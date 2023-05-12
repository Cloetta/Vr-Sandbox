using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOptionsButton : MonoBehaviour
{
    [SerializeField]
    GameObject optionsMenu;
    ItemManager item;
    GameObject player;
    Inventory inventory;


    //Script not currently in use, kept for reference

    public void ShowOptionPanel()
    {
        optionsMenu.SetActive(true);
    }

    public void CancelOptionPanel()
    {
        optionsMenu.SetActive(false);
    }

    public void UseItem()
    {
        Debug.Log("Item Used!");
    }

    public void ExamineItem()
    {
        Debug.Log("Item examined!");
    }

    public void DiscardItem()
    {
        Debug.Log("Item Discarded!");

        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 spawnPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1f);

        Instantiate(item, spawnPosition, player.transform.rotation);

        Inventory.instance.DeleteItem(item);

    }
}
