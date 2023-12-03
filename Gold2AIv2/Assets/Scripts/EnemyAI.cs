using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    [SerializeField] private float startingHealth;
    [SerializeField] private float lowHealthThreshold;
    [SerializeField] private float healthRestoreRate;

    [SerializeField] private float runRange;
    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;


    [SerializeField] private Transform playerTransform;


    private Material material;
    private NavMeshAgent agent;

    private Node topNode;

    private float currentHealth;
    public float CurrentHealth {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, startingHealth); }
    }


    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    private void Start() {
        currentHealth = startingHealth;
        ConstructBehahaviourTree();
    }

    private void ConstructBehahaviourTree() {
        // Helper
        HealthNode healthNode = new(this, lowHealthThreshold);

        // Retreat!
        RangeNode runningRangeNode = new(runRange, playerTransform, transform);
        RunNode runNode = new(playerTransform, runRange, agent, this);

        // Chase
        RangeNode chasingRangeNode = new(chasingRange, playerTransform, transform);
        ChaseNode chaseNode = new(playerTransform, agent, this);

        // "Shoot"
        RangeNode shootingRangeNode = new(shootingRange, playerTransform, transform);
        ShootNode shootNode = new(agent, this, playerTransform);

        // Healing
        HealNode healNode = new(playerTransform, healthRestoreRate, agent, this);

        // Patrolling

        Sequence runSequence = new(new() { healthNode, runningRangeNode, runNode });
        Sequence healSequence = new(new(){healthNode, healNode});
        Sequence shootSequence = new(new() { shootingRangeNode, shootNode });
        Sequence chaseSequence = new(new() { chasingRangeNode, chaseNode });
        

        topNode = new Selector(new() { runSequence, healSequence, shootSequence, chaseSequence });
    }


    private void Update() {
        topNode.Evaluate();
        if (topNode.NodeState == NodeState.FAILURE) {
            SetColor(Color.red);
            agent.isStopped = true;
        }
    }


    public void ApplyDamage(float damage) {
        CurrentHealth -= damage;
    }

    public void ApplyHeal(float heal) {
        CurrentHealth += heal;
    }

    public void SetColor(Color color) {
        material.color = color;
    }

}