using UnityEngine;
using UnityEngine.AI;

public class DirectionFreeNode : Node {

    private NavMeshAgent agent;
    private EnemyAI ai;
    private LayerMask mask;
    private Vector2 randomPoint;
    private float distanceToPatrol;

    public DirectionFreeNode(NavMeshAgent agent, float distanceToPatrol, Vector2 randomPoint, EnemyAI ai) {
        this.agent = agent;
        this.ai = ai;
        this.distanceToPatrol = distanceToPatrol;
        this.randomPoint = randomPoint;
    }


    public override NodeState Evaluate() {
        Vector3 randomDirection = new(randomPoint.x,0,randomPoint.y);

        Ray ray = new(ai.transform.position, randomDirection);
        Debug.DrawRay(ray.origin, ray.direction * distanceToPatrol, Color.red, 2f);

        return Physics.Raycast(ray, out RaycastHit hit, distanceToPatrol) ? NodeState.FAILURE : NodeState.SUCCESS;

    }
}