using System.Collections;

using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float maxDistance;
    private void Start() {
        StartCoroutine(TimedBullet());
    }

    private void Update() {
        if (Vector3.Distance(transform.position, FindAnyObjectByType<Shooting>().transform.position) > maxDistance) {
            RemoveMe();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.TryGetComponent<EnemyAI>(out var ai)) {
            ai.ApplyDamage(FindAnyObjectByType<Shooting>().Damage);
            ai.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
            Debug.Log(ai.CurrentHealth);
            RemoveMe();
        }
    }

    IEnumerator TimedBullet() {
        yield return new WaitForSeconds(2);
        RemoveMe();
    }

    private void RemoveMe() {
        Destroy(gameObject);
    }
}