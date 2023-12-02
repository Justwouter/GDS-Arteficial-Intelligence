using System.Collections.Generic;

public class Selector : Node {
    protected List<Node> nodes = new();

    public Selector(List<Node> nodes) {
        this.nodes = nodes;
    }

    public override NodeState Evaluate() {

        foreach (Node node in nodes) {
            switch (node.Evaluate()) {
                case NodeState.RUNNING:
                    state = NodeState.RUNNING;
                    return state;
                case NodeState.SUCCESS:
                    state = NodeState.SUCCESS;
                    return state;
                case NodeState.FAILURE:
                    break;
                default:
                    break;
            }

        }
        state = NodeState.FAILURE;
        return state;
    }
}