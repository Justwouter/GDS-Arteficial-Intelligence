using System.Collections.Generic;

public class Sequence : Node {
    protected List<Node> nodes = new();

    public Sequence(List<Node> nodes) {
        this.nodes = nodes;
    }

    public override NodeState Evaluate() {
        bool isAnyRunning = false;
        foreach (Node node in nodes) {
            switch (node.Evaluate()) {
                case NodeState.RUNNING:
                    isAnyRunning = true;
                    break;
                case NodeState.SUCCESS:
                    break;
                case NodeState.FAILURE:
                    state = NodeState.FAILURE;
                    return state;
                default:
                    break;
            }

        }
        state = isAnyRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return state;
    }
}