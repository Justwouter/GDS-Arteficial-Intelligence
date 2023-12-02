using System.Collections;

using UnityEngine;

public class PatrolBehaviour : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float restTime;

    [Header("Route")]
    [SerializeField] private Transform[] route;
    private int routeIndex = 0;
    private bool isResting = false;


    void Update() {
        if (transform.position != route[routeIndex].position) {
            transform.position = Vector3.MoveTowards(transform.position, route[routeIndex].position, speed * Time.deltaTime);
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


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        for (int i = 0; i < route.Length; i++) {
            Vector3 start = route[i].position;
            Vector3 destination = i < route.Length - 1 ? route[i + 1].position : route[0].position;
            Gizmos.DrawLine(start, destination);
        }
    }
}