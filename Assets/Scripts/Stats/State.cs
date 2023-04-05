using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public float currentHealth = 0;
    public float maxHealth = 0;
    public bool isDead = false;

    StartingStats startStats;


    void Start()
    {
        startStats = GetComponent<StartingStats>();
        maxHealth = startStats.GetStat(Stat.HealthPoints);
        currentHealth = maxHealth;
        //Debug.Log(health);

    }

    public bool IsDead()
    {
        return isDead;
    }

    /*
    public void TakingDamage(GameObject attacker, float damage)
    {
        PlayerController playerStats = GetComponent<PlayerController>();

        //afterDefense = Mathf.Max(damage - playerStats.defense, 1);

        //debug line
        Debug.Log(gameObject.name + "took damage: " + damage);

        //Returning the max of two values to avoid health to go below 0 (if after taking damage health is negative, then it returns 0)
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        if (currentHealth <= 0)
        {
            Die();
            //GiveExpPoints(attacker);
        }
    }

    */

    public void Die()
    {
        isDead = true;
    }
    

}
