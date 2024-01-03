using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class RegularBehaviour : ABehaviour {

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    public new void Update() {
        base.Update();
        if (isActive) {
            agent.speed = speed;
            agent.SetDestination(V3NoY(target));
        }
    }

    


    
}
