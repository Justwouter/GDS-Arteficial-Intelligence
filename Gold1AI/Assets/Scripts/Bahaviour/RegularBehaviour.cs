using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class RegularBehaviour : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private bool isActive = false;

    [Header("Route")]
    [SerializeField] private PatrolPoint target;

    private NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update() {
        if (isActive) {
            agent.speed = speed;
            agent.SetDestination(target.transform.position);
        }
    }

    public void SetEnabled() {
        isActive = true;
        agent.enabled = true;
    }

    public void SetDisabled() {
        isActive = false;
        agent.enabled = false;
    }


    /// <summary>
    /// Quick and stupid way to ignore hight values when comparing vectors
    /// </summary>
    /// <param name="inputVector"></param>
    /// <returns></returns>
    private Vector3 V3NoY(Vector3 inputVector) {
        return new Vector3(inputVector.x, 1, inputVector.z);
    }
}
