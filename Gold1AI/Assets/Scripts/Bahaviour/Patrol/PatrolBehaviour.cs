using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : ABehaviour {
  
    private int routeIndex = 0;
    private bool isResting = false;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update() {
        if (isActive) {
            agent.speed = speed;
            Vector3 nextPosition = V3NoY(route[routeIndex].transform.position);
            if (V3NoY(transform.position) != nextPosition) {
                agent.SetDestination(nextPosition);
            }
            else {
                if (!isResting) {
                    StartCoroutine(RestAtPoint());
                }
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
    

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        for (int i = 0; i < route.Length; i++) {
            Vector3 start = route[i].transform.position;
            Vector3 destination = i < route.Length - 1 ? route[i + 1].transform.position : route[0].transform.position;
            Gizmos.DrawLine(start, destination);
        }
    }
}