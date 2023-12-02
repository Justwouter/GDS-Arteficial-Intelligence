using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HealBehaviour : Behaviour {
    [Header("To Target")]
    [SerializeField] private Transform target;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float minimumDistance;

    [Header("Healing")]
    [SerializeField] private float healRate;

    public HealBehaviour(Transform target, float speed, float minimumDistance, float healRate) {
        this.target = target;
        this.speed = speed;
        this.minimumDistance = minimumDistance;
        this.healRate = healRate;
    }

    void Start() {

    }

    public override void Update() {
        
    }
}
