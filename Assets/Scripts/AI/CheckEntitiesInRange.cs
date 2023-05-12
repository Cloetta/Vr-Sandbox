using BehaviourTree;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CheckEntitiesInRange : Node
{
    private static int enemyLayerMask = 1 << 6;
    private static int enemyLayerMask2 = 1 << 7;//layer 6 and 7 (layer Player and Ally)
    private Transform transform;
    private Animator animator;

    public CheckEntitiesInRange(Transform pTransform)
    {
        transform = pTransform;
        animator = transform.GetComponent<Animator>();

        if (transform.CompareTag("Ally"))
        {
            enemyLayerMask = 1 << 8;
            enemyLayerMask2 = 1 << 8;
        }
        else if (transform.CompareTag("Enemy"))
        {
            enemyLayerMask = 1 << 6;
            enemyLayerMask2 = 1 << 7;
        }
    }   

    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target == null)
        {
            float fov = 0;

            if (transform.CompareTag("Ally"))
            {
                fov = AllyBT.fieldOfViewRange;
            }
            else if (transform.CompareTag("Enemy"))
            {
                fov = EnemyBT.fieldOfViewRange;


            }

            int combinedMask = enemyLayerMask | enemyLayerMask2;

            Collider[] colliders = Physics.OverlapSphere(transform.position, fov, combinedMask);
            

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                animator.SetBool("isWalking", true);

                state = NodeState.SUCCESS;
                return state;
            }
            else
            {

                state = NodeState.FAILURE;
                return state;
            }



        }

        state = NodeState.SUCCESS;
        return state;
    }
}
