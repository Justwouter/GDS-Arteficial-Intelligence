using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float restTime;

    [Header("Route")]
    [SerializeField] private PatrolPoint[] route;


    private int routeIndex = 0;
    private bool isResting = false;
    private NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update() {
        Vector3 nextPosition = route[routeIndex].transform.position;
        if (V3NoY(transform.position) != V3NoY(nextPosition)) {
            agent.SetDestination(nextPosition);
        }
        else {
            if (!isResting) {
                StartCoroutine(RestAtPoint());
            }
        }

    }

    IEnumerator RestAtPoint() {
        isResting = true;
        yield return new WaitForSeconds(restTime);
        if (routeIndex == route.Length - 1) {
            routeIndex = 0;
        }
        else {
            routeIndex++;
        }
        isResting = false;
    }

    /// <summary>
    /// Quick and stupid way to ignore hight values when comparing vectors
    /// </summary>
    /// <param name="inputVector"></param>
    /// <returns></returns>
    private Vector3 V3NoY(Vector3 inputVector){
        return new Vector3(inputVector.x,0,inputVector.z);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        for (int i = 0; i < route.Length; i++) {
            Vector3 start = route[i].transform.position;
            Vector3 destination = i < route.Length - 1 ? route[i + 1].transform.position : route[0].transform.position;
            Gizmos.DrawLine(start, destination);
        }
    }
}