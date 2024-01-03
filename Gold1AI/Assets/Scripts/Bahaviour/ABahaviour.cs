// The whole behaviour thing can arguably be improved with some nice abstraction but it is 3am and I am way to lazy to do that.

using UnityEngine;
using UnityEngine.AI;

public abstract class ABehaviour : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] protected float speed;
    [SerializeField] protected float restTime;
    [SerializeField] protected bool isActive = true;

    [Header("Route")]
    [SerializeField] protected PatrolPoint[] route;
    [SerializeField] protected Vector3 target;
    protected GameManager gameManager;

    protected NavMeshAgent agent;
    protected Material material;

    protected void Start() {
        material = GetComponent<MeshRenderer>().material;
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void SetEnabled() {
        agent.isStopped = false;
        isActive = true;
    }

    public void SetDisabled() {
        agent.isStopped = true;
        isActive = false;

    }
    protected void Update() {
        if(gameManager != null )
            if (gameManager.SelectedAgent == gameObject) {
                GetComponent<MeshRenderer>().material = gameManager.SelectedMaterial;
            }
            else {
                GetComponent<MeshRenderer>().material = material;
            }
    }

    public void ToggleEnabled() {
        if (isActive) {
            SetDisabled();
        }
        else {
            SetEnabled();
        }
    }

    public void SetRoute(PatrolPoint[] newRoute) {
        route = newRoute;
    }

    public PatrolPoint[] GetRoute() {
        return route;
    }

    public void SetTarget(Vector3 newTarget) {
        target = newTarget;
    }
    public Vector3 GetTarget() {
        return target;
    }

    /// <summary>
    /// Quick and stupid way to ignore hight values when comparing vectors
    /// </summary>
    /// <param name="inputVector"></param>
    /// <returns></returns>
    public Vector3 V3NoY(Vector3 inputVector) {
        return new Vector3(inputVector.x, 1, inputVector.z);
    }
}