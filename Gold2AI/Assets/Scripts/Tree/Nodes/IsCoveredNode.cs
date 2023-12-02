using UnityEngine;

public class IsCoveredNode : Node {
    private Transform origin;
    private Transform target;

    public IsCoveredNode(Transform origin, Transform target) {
        this.origin = origin;
        this.target = target;
    }

    public override NodeState Evaluate() {
        if (Physics.Raycast(origin.position, target.position - origin.position, out RaycastHit hit)) {
            if (hit.collider.transform != target){
                return NodeState.SUCCESS;
            }
        }
        return NodeState.FAILURE;
    }
}