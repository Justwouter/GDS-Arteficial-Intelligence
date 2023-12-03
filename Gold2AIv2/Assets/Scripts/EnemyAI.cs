

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
        HealthNode healthTresholdNode = new(lowHealthThreshold, this);

        // Retreat!
        RangeNode runningRangeNode = new(runRange, playerTransform, transform);
        RunNode runNode = new(playerTransform, runRange, agent, this);

        // Chase
        RangeNode chasingRangeNode = new(chasingRange, playerTransform, transform);
        ChaseNode chaseNode = new(playerTransform, agent, this);

        // "Shoot"
        RangeNode shootingRangeNode = new(shootingRange, playerTransform, transform);
        ShootNode shootNode = new(agent, playerTransform, this);

        // Healing
        HealNode healNode = new(playerTransform, healthRestoreRate, agent, this);

        // Patrolling
        Inverter rangeInverter = new(chasingRangeNode);
        PatrolNode patrolNode = new(agent, 20f, 1f, this);

        // Death
        HealthNode healthDeathNode = new(0.1f, this);
        DeathNode deathNote = new(this); // ;)


        // Sequence nodes
        Sequence runSequence = new(new() { healthTresholdNode, runningRangeNode, runNode });
        Sequence healSequence = new(new() { healthTresholdNode, healNode });
        Sequence shootSequence = new(new() { shootingRangeNode, shootNode });
        Sequence chaseSequence = new(new() { chasingRangeNode, chaseNode });
        Sequence patrolSequence = new(new() { rangeInverter, patrolNode });
        Sequence deathSequence = new(new() { healthDeathNode, deathNote});

        topNode = new Selector(new() {deathSequence, runSequence, healSequence, shootSequence, chaseSequence, patrolSequence });
        // topNode = new Selector(new() { });

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