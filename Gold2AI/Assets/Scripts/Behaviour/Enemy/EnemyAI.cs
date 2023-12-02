using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField] private float startingHealth;
    [SerializeField] private float lowHealthTrashold;
    [SerializeField] private float healthRestoreRate;

    [SerializeField] private float chaseRange;
    [SerializeField] private float shootRange;

    [SerializeField] private Transform targetTransform;

    private Material material;

    private float currentHealth {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, startingHealth); }
    }

    private void Start() {
        currentHealth = startingHealth;
        material = GetComponent<MeshRenderer>().material;
    }

    public float GetCurrentHealth() {
        return currentHealth;
    }
    public void SetColor(Color color) {
        material.color = color;
    }

}