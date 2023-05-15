using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] StartingStats player;

    [SerializeField] private SkillTree skillTree;

    [SerializeField] Abilities ability;

    float cooldownTimer = 0;
    private bool isCooldown = false;

    void Start()
    {
        skillTree.SetPlayerSkills(player.GetPlayerSkills());
    }



    public InputActionProperty testButton;

    // Update is called once per frame
    void Update()
    {
        if (testButton.action.WasPressedThisFrame())
        {
            /*if (player.CanUseSkill1())
            {
                Debug.Log("Using skill 1!");

            }
            else
            {
                Debug.Log("Nope!");
            }*/


            //player.GetComponent<State>().currentHealth -= 1;
            //player.GetComponent<State>().currentMana -= 1;

            UseSkill();


        }

        
    }




    public void UseSkill()
    {

        if (player.CanUseSkill(ability.ability) && ability.type == Abilities.Type.Active)
        {
            //cHeck if the cooldown of the skill is active
            if (isCooldown)
            {
                //Notify we can't use the skill
                Debug.Log("Skill in cooldown!");

                //return false;
            }
            else
            {
                if (ability != null)
                {
                    /*Debug.Log("Skill used!" + ability.name);
                    SkillEffect(ability.name, skill.hpHeal, skill.sugarHeal, skill.damageToEnemy, skill.skillCooldown, skill.sugarCost);
                    isCooldown = true;
                    txtCooldown.gameObject.SetActive(true);
                    //Set the cooldown time to the skillcooldown value of the skill assigned 
                    cooldownTimer = ability.cooldown;*/
                }
                else if (ability == null)
                {
                    Debug.Log("You have no skill equipped on this slot");
                }
            }
        }
        else
        {
            Debug.Log("Skill not unlocked!");
        }



        
    }

    public void SkillEffect(string skillName, int skillHpHeal, int skillSugarHeal, int skillDamage, float skillCooldown, int skillSugarCost)
    {

        /*
        //Validate the HP/Sugar(mana) value doesn't go above the max causing irregularities
        if (currentSugar >= skillSugarCost)
        {
            //animation of the skill effect, same trigger or whatever to make it work :\
            skillAnimation.GetComponent<Animator>().SetTrigger(skillName);



            //Apply skill effects to player values
            currentSugar -= skillSugarCost;
            currentHealth += skillHpHeal;
            currentSugar += skillSugarHeal;


            //Look for all the enemy hit in the range area 
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, playerAttackRange, enemyLayers);

            //For each enemy identified, look for its "combat" component and trigger its function to apply the damage
            foreach (Collider2D enemy in hitEnemy)
            {
                Debug.Log("Enemy name is: " + enemy.name);

                if (enemy.name == "Boss")
                {
                    enemy.GetComponent<BossCombat>().EnemyTakingDamage(skillDamage);
                }
                else
                {
                    enemy.GetComponent<EnemyCombat>().EnemyTakingDamage(skillDamage);
                }

                //Line for debugging purposes
                //Debug.Log("We hit " + enemy.name);
            }

            //Line for debugging purposes
            //Debug.Log("Sugar spent:" + skillSugarCost + "/ Damage: " + skillDamage + "/ Heal: " + skillHpHeal);
        }
        else
        {
            //Line for debugging purposes
            Debug.Log("Not enough mana");
        }*/
    }
}
