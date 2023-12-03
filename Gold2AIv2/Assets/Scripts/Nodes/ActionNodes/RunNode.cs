using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class RunNode : Node {
    private NavMeshAgent agent;
    private EnemyAI ai;
    private Transform target;
    private float minimumDistance;

    public RunNode(Transform target, float minimumDistance, NavMeshAgent agent, EnemyAI ai) {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
        this.minimumDistance = minimumDistance;
    }

    public override NodeState Evaluate() {
        ai.SetColor(Color.blue);
        float distance = Vector3.Distance(agent.transform.position, target.position);
        Debug.Log(distance + " " + minimumDistance);

        if (distance < minimumDistance) {
            Debug.Log("I work!");
            agent.isStopped = false;
            agent.SetDestination(agent.transform.position + (agent.transform.position - target.position));
            return NodeState.RUNNING;
        }
        else {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }


}