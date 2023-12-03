using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class PatrolNode : Node {
    private NavMeshAgent agent;
    private EnemyAI ai;
    private float distanceToPatrol;
    private Vector2 randomPoint;
    float patrolDelay;
    Vector3 randomPosition;

    public PatrolNode(NavMeshAgent agent, float distanceToPatrol, float patrolDelay, EnemyAI ai) {
        this.agent = agent;
        this.ai = ai;
        this.distanceToPatrol = distanceToPatrol;
        this.patrolDelay = patrolDelay;
    }

    public override NodeState Evaluate() {
        ai.SetColor(Color.white);

        if (agent.isStopped) {
            randomPosition = GetRandomPosition();
            ai.StartCoroutine(PatrolPointSwitchDelay(patrolDelay));
        }


        // Check if there are obstacles in front of the AI
        if (Physics.Raycast(agent.transform.position, randomPosition - agent.transform.position, out RaycastHit hit, distanceToPatrol)) {
            // If obstacles are present, choose a new random position
            randomPosition = GetRandomPosition();
        }

        float distance = Vector3.Distance(randomPosition, agent.transform.position);

        if (distance > 0.2f) {
            agent.isStopped = false;
            agent.SetDestination(randomPosition);
            return NodeState.RUNNING;
        }
        else {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }

    IEnumerator PatrolPointSwitchDelay(float delay) {
        yield return new WaitForSeconds(delay);
    }

    private Vector3 GetRandomPosition() {
        // Square arround agent
        float randomX = Random.Range(agent.transform.position.x - distanceToPatrol, agent.transform.position.x + distanceToPatrol);
        float randomZ = Random.Range(agent.transform.position.z - distanceToPatrol, agent.transform.position.z + distanceToPatrol);

        Vector3 randomPosition = new(randomX, agent.transform.position.y, randomZ);
        return randomPosition;
    }

}