using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using JetBrains.Annotations;

public class TaskGoToTarget : Node
{
    private Transform transform;

    public TaskGoToTarget(Transform pTransform)
    {
        transform = pTransform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if(Vector3.Distance(transform.position, target.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, EnemyBT.speed * Time.deltaTime);
            transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
