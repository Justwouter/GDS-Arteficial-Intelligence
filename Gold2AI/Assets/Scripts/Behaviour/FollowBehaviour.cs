using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FollowBehaviour : Behaviour {
    [Header("To Track")]
    [SerializeField] private Transform target;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float minimumDistance;
    [SerializeField] private bool shouldChase = true;

    public FollowBehaviour(Transform target, float speed, float minimumDistance) {
        this.target = target;
        this.speed = speed;
        this.minimumDistance = minimumDistance;
    }

    void Start() {

    }

    public override void Update() {
        if (shouldChase && Vector3.Distance(transform.position, target.position) > minimumDistance) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else {
            // to close to move, attack or smth
        }
    }
}
