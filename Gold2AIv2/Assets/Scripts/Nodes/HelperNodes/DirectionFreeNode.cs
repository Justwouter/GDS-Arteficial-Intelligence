using UnityEngine;
using UnityEngine.AI;

public class DirectionFreeNode : Node {

    private NavMeshAgent agent;
    private EnemyAI ai;
    private LayerMask mask;

    private float distanceToPatrol;

    public DirectionFreeNode(NavMeshAgent agent, EnemyAI ai, float distanceToPatrol) {
        this.agent = agent;
        this.ai = ai;
        this.distanceToPatrol = distanceToPatrol;
    }


    public override NodeState Evaluate() {
        Vector3 randomDirection = Random.onUnitSphere;

        // Perform the raycast from the current position in the random direction
        Ray ray = new(ai.transform.position, randomDirection);

        if (Physics.Raycast(ray, out RaycastHit hit, distanceToPatrol)) {
            // Ray hit something, you can access hit information here
            return NodeState.FAILURE;
        }
        else {
            return NodeState.SUCCESS;
        }

        
    }
}