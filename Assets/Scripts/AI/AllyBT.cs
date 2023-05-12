using BehaviourTree;
using System.Collections.Generic;

public class AllyBT : Tree
{
    public UnityEngine.Transform player;

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
            new TaskFollowPlayer(transform, player),
        });

        return root;
    }


}
