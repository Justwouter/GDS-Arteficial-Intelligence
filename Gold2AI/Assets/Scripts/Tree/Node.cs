using System;

[Serializable]
public abstract class Node {
    protected NodeState state;
    public NodeState State { get { return state; } }

    public abstract NodeState Evaluate();
}

public enum NodeState {
    RUNNING, SUCCESS, FAILURE
}