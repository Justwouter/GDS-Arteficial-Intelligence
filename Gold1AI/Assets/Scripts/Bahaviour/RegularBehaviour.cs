using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class RegularBehaviour : ABehaviour {

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    public new void Update() {
        if(target == Vector3.zero){
            SetTarget(V3NoY(transform.position));
        }
        base.Update();
        if (isActive) {
            agent.speed = speed;
            agent.SetDestination(V3NoY(target));
        }
    }

    


    
}
