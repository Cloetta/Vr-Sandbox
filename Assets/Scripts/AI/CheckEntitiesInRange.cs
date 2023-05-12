using BehaviourTree;
using UnityEditor;
using UnityEngine;

public class CheckEntitiesInRange : Node
{
    private static int enemyLayerMask = 6 << 7; //layer 6 and 7 (layer Player and Ally)
    private Transform transform;
    private Animator animator;

    public CheckEntitiesInRange(Transform pTransform)
    {
        transform = pTransform;
        animator = transform.GetComponent<Animator>();
    }   

    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, EnemyBT.fieldOfViewRange, enemyLayerMask);

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
