using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{

    public Transform head;
    public float spawnDistance = 2;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject skillTree;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject movementRecognizer;

    public InputActionProperty showButton;

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {

            if (!skillTree.activeInHierarchy && !inventory.activeInHierarchy)
            {
                menu.SetActive(!menu.activeSelf);

                if (menu.activeInHierarchy)
                {

                    Time.timeScale = 0;
                    movementRecognizer.SetActive(false);
                }
                else
                {
                    Time.timeScale = 1;
                    movementRecognizer.SetActive(true);
                }
            }

               
            menu.transform.position = head.position + new Vector3(head.forward.x, 0.5f, head.forward.z).normalized * spawnDistance;
        }

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }
    

    public void OpenSkillTree()
    {
        skillTree.SetActive(!skillTree.activeSelf);
        skillTree.transform.position = head.position + new Vector3(head.forward.x, 0.65f, head.forward.z).normalized * spawnDistance;
        skillTree.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        skillTree.transform.forward *= -1;
    }

    public void OpenInventory()
    {
        inventory.SetActive(!inventory.activeSelf);
        inventory.transform.position = head.position + new Vector3(head.forward.x, 0.65f, head.forward.z).normalized * spawnDistance;
        inventory.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        inventory.transform.forward *= -1;
    }
}
