using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using JetBrains.Annotations;
using UnityEngine.AI;

public class TaskGoToTarget : Node
{
    private Transform transform;
    private NavMeshAgent agent;
    

    public TaskGoToTarget(Transform pTransform)
    {
        transform = pTransform;
        agent = transform.GetComponent<NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if(Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            agent.destination = Vector3.MoveTowards(transform.position, target.position, EnemyBT.speed * Time.deltaTime);
            transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
