public class HealthNode : Node {
    private EnemyAI ai;
    private float treshold;

    public HealthNode(EnemyAI ai, float treshold) {
        this.ai = ai;
        this.treshold = treshold;
    }

    public override NodeState Evaluate() {
        state = ai.GetCurrentHealth() < treshold ? NodeState.SUCCESS : NodeState.FAILURE;
        return state;
    }
}