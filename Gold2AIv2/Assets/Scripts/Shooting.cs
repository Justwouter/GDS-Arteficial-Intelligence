using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Shooting : MonoBehaviour {
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private float damage;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    private void Shoot() {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, mask)) {
            if (hit.collider.TryGetComponent<EnemyAI>(out var ai)) {
                ai.ApplyDamage(damage);
                Debug.Log(ai.CurrentHealth);
            }
        }
    }
}