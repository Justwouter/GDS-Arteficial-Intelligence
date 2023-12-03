using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class HealNode : Node {
    private NavMeshAgent agent;
    private EnemyAI ai;
    private Transform target;
    private float healRate;

    public HealNode(Transform target, float healRate, NavMeshAgent agent, EnemyAI ai) {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
        this.healRate = healRate;
    }

    public override NodeState Evaluate() {
        ai.SetColor(Color.green);

        if(agent.isStopped){
            return NodeState.RUNNING;
        }
        else{
            ai.StartCoroutine(WaitForHeal());
            return NodeState.SUCCESS;
        }
    }

    IEnumerator WaitForHeal(){
        agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        ai.ApplyHeal(healRate);
        agent.isStopped = false;
    }


}