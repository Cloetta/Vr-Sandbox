using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEngine.AI;

public class TaskFollowPlayer : Node
{
    public Transform transform;
    public Transform player;

    private Animator animator;
    private NavMeshAgent agent;
    

    private int currentWaypointIndex = 0;
    //private float speed = 2f;

    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool stopping = false;


    public TaskFollowPlayer(Transform pTransform, Transform pPlayer)
    {
        transform = pTransform;
        player = pPlayer;
        animator = transform.GetComponent<Animator>();
        agent = transform.GetComponent<NavMeshAgent>();
    }


    public override NodeState Evaluate()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector3.Distance(transform.position, player.position) < 2f)
        {
            agent.destination = transform.position;
            stopping = true;
            animator.SetBool("isWalking", false);
        }
        else
        {
            stopping = false;
            animator.SetBool("isWalking", true);
            agent.destination = Vector3.MoveTowards(transform.position, player.position, AllyBT.speed * Time.deltaTime);
            transform.LookAt(player.position);
        }
        
        
        state = NodeState.RUNNING;
        return state;
        

    }
}
