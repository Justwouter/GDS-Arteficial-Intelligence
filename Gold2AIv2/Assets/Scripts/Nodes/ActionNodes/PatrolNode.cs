using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class PatrolNode : Node {
    private NavMeshAgent agent;
    private EnemyAI ai;
    private LayerMask mask;

    private float distanceToPatrol;

    public PatrolNode(NavMeshAgent agent, EnemyAI ai, float distanceToPatrol) {
        this.agent = agent;
        this.ai = ai;
        this.distanceToPatrol = distanceToPatrol;
    }

    public override NodeState Evaluate() {
        ai.SetColor(Color.magenta);
        return NodeState.SUCCESS;




    }
}