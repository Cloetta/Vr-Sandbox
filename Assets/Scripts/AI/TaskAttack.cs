using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class TaskAttack : Node
{
    private Transform lastTarget;
    private State enemyManager;
    private Animator animator;

    private float attackTime = 1f;
    private float attackCounter = 0f;

    private GameObject attacker;

    public TaskAttack(Transform pTransform)
    {
        animator = pTransform.GetComponent<Animator>();
        attacker = animator.gameObject;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        
        if(target != lastTarget)
        {
            enemyManager = target.GetComponentInChildren<State>();
            lastTarget = target;
        }

        attackCounter += Time.deltaTime;

        if(attackCounter >= attackTime)
        {
            float damage = 10f;


            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);
            //enemyManager = target.GetComponent<State>();
            enemyManager.TakingDamage(attacker, damage);



            if (enemyManager.isDead == true)
            {
                ClearData("target");
                animator.SetBool("isAttacking", false);
                animator.SetBool("isWalking", true);
            }
            else
            {
                attackCounter = 0f;
            }



            
        }

        state = NodeState.RUNNING;
        return state;
    }


}
