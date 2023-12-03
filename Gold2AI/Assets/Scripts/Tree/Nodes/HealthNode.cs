public class HealthNode : Node {
    private EnemyController controller;
    private float treshhold;

    public HealthNode(EnemyController controller) {
        this.controller = controller;
    }

    public override NodeState Evaluate() {
        if(controller.CurrentHealth < treshhold){
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}