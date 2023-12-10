using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class RegularBehaviour : ABehaviour {

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update() {
        if (isActive) {
            agent.speed = speed;
            agent.SetDestination(target.transform.position);
        }
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
