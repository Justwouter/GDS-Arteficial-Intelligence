using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RetreatBehaviour : Behaviour {
    [Header("To Chase")]
    [SerializeField] private Transform target;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float minimumDistance;
    [SerializeField] private bool shouldRetreat = true;

    public RetreatBehaviour(Transform target, float speed, float minimumDistance, bool shouldRetreat) {
        this.target = target;
        this.speed = speed;
        this.minimumDistance = minimumDistance;
        this.shouldRetreat = shouldRetreat;
    }

    void Start() {

    }

    public override void Update() {
        if (shouldRetreat && Vector3.Distance(transform.position, target.position) < minimumDistance) {
            transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            -speed * Time.deltaTime); // Negative speed so move backwarts
        }
    }
}
