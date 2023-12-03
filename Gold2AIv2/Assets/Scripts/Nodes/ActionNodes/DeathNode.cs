using UnityEngine;

public class DeathNode : Node {

    private EnemyAI ai;

    public DeathNode(EnemyAI ai) {
        this.ai = ai;
    }

    public override NodeState Evaluate() {
        Object.Destroy(ai.transform.gameObject);
        return NodeState.SUCCESS;
    }
}