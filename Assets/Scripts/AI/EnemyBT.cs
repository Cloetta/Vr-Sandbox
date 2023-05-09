using BehaviourTree;
using System.Collections.Generic;

public class EnemyBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;

    public static float fieldOfViewRange = 6f;

    public static float attackRange = 1f;


    protected override Node SetupTree()
    {
        //The order of the tasks sets the priority 


        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node>
            {
                new CheckEntitiesInAttackRange(transform),
                new TaskAttack(transform),
            }),
            new Sequence (new List<Node> 
            {
                new CheckEntitiesInRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }


}
