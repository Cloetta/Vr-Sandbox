using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class TaskPatrol : Node
{
    public Transform transform;
    private Transform[] waypoints;

    private Animator animator;

    private int currentWaypointIndex = 0;
    //private float speed = 2f;

    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;


    public TaskPatrol(Transform pTransform, Transform[] pWaypoints)
    {
        transform = pTransform;
        waypoints = pWaypoints;
        animator = transform.GetComponent<Animator>();
    }


    public override NodeState Evaluate()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                waiting = false;
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            Transform wp = waypoints[currentWaypointIndex];

            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;

                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                animator.SetBool("isWalking", false);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, wp.position, EnemyBT.speed * Time.deltaTime);
                transform.LookAt(wp.position);
            }
        }
        
        state = NodeState.RUNNING;
        return state;
        

    }
}
