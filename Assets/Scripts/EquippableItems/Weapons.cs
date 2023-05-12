using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "RPGMechanics/New Weapon", order = 1)]
public class Weapons : ItemManager
{
    [SerializeField]
    GameObject weaponEquipped = null;


    public EquipSlot equipSlot; 
    
    public float weaponRange = 0f; 

    public float weaponDamage = 0f;
    public float weaponDefense = 0f;

    //public string type = "";
    //public string description = "";


    //add animator later for different animations 
    public void GetWeapon(Transform handTransform) //Animator animator )
    {
        Instantiate(weaponEquipped, handTransform);
        //animator.runtimeAnimatorController = weaponOverride;

        
    }

    public enum EquipSlot { RightHand, LeftHand };

    public void EquipItem()
    {
        //EquipManager.instance.Equip(this);

    }


    public float GetDamage()
    {
        return weaponDamage;
    }

    public float GetRange()
    {
        return weaponRange;
    }

    public float GetDefense()
    {
        return weaponDefense;
    }

    //for tooltips later - it was imported but not implemented
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
