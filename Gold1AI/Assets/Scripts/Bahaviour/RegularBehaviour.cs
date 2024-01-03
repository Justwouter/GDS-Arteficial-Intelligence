using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class RegularBehaviour : ABehaviour {

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update() {
        if (isActive) {
            agent.speed = speed;
            agent.SetDestination(target.transform.position);
        }
    }

    


    
}
