using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class State : MonoBehaviour
{
    public float currentHealth = 0;
    public float maxHealth = 0;
    public float maxMana = 0;
    public float currentMana = 0; 
    public bool isDead = false;
    StartingStats startStats;
    private float manaRegenTime;

    //StartingStats startStats;


    void Start()
    {
        startStats = GetComponent<StartingStats>();

        //---- recheck this after training for final version of build----//
        maxHealth = startStats.GetStat(Stat.HealthPoints);
        maxMana = startStats.GetStat(Stat.MagicPoints);
        currentMana = maxMana;
        currentHealth = maxHealth;

        //Debug.Log(health);

    }

    private void Update()
    {
        //Condition to trigger mana regeneration, 1% of max mana per second
        if (maxMana > currentMana)
        {
            if (Time.time >= manaRegenTime)
            {

                currentMana+= maxMana * 0.01f;
                manaRegenTime = Time.time + 1f;
            }
        }

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    public bool IsDead()
    {
        return isDead;
    }


    public void TakingDamage(GameObject attacker, float damage)
    {
        //PlayerController playerStats = GetComponent<PlayerController>();

        //afterDefense = Mathf.Max(damage - playerStats.defense, 1);

        //debug line
        //Debug.Log(gameObject.name + "took damage: " + damage);

        //Returning the max of two values to avoid health to go below 0 (if after taking damage health is negative, then it returns 0)
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        if (currentHealth <= 0)
        {
            Die();
            GiveExpPoints(attacker);
        }
    }

    public void Die()
    {
        isDead = true;
        //Destroy(this.gameObject);
    }

    public float GetSlideBarValue()
    {

        float sliderValue = 100 * (currentHealth / maxHealth);
        return sliderValue;
    }

    private void GiveExpPoints(GameObject attacker)
    {
        ExperienceManager expManager = attacker.GetComponent<ExperienceManager>();
        if (expManager == null)
        {
            return;
        }

        //Getting the reward exp for the attacker/player
        expManager.GainedExp(GetComponent<StartingStats>().GetStat(Stat.Reward));
    }


    public float GetHP()
    {
        return currentHealth;
    }

    public float GetMaxHP()
    {
        return GetComponent<StartingStats>().GetStat(Stat.HealthPoints);
    }
}
