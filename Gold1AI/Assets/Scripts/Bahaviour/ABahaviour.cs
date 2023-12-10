// The whole behaviour thing can arguably be improved with some nice abstraction but it is 3am and I am way to lazy to do that.
// At least to lazy to do it now while debugging stuff in the editor :/

using UnityEngine;
using UnityEngine.AI;

public abstract class ABehaviour : MonoBehaviour, IBehaviour {
    [Header("Movement")]
    [SerializeField] protected float speed;
    [SerializeField] protected float restTime;
    [SerializeField] protected bool isActive = false;

    [Header("Route")]
    [SerializeField] protected PatrolPoint[] route;
    [SerializeField] protected PatrolPoint target;


    protected NavMeshAgent agent;


    public void SetEnabled() {
        isActive = true;
        agent.enabled = true;
    }

    public void SetDisabled() {
        isActive = false;
        agent.enabled = false;
    }

    public void ToggleEnabled() {
        isActive = !isActive;
        agent.enabled = !agent.enabled;
    }
}