using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEngine.XR;

public class CheckEntitiesInAttackRange : Node
{
    private static int enemyLayerMask  = 6 << 7;

    private Transform transform;
    private Animator animator;

    public CheckEntitiesInAttackRange(Transform pTransform)
    {
        transform = pTransform;
        animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector3.Distance(transform.position, target.position) <= EnemyBT.attackRange)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);

            state = NodeState.SUCCESS;
            return state;
        }
        
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", true);
        

        state = NodeState.FAILURE;
        return state;
    }
}
