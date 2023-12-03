using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Shooting : MonoBehaviour {
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float damage;
    [SerializeField] private float projectileSpeed;
    
    public float Damage { get { return damage; } }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    private void Shoot() {
        // if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, mask)) {
        //     if (hit.collider.TryGetComponent<EnemyAI>(out var ai)) {
        //         ai.ApplyDamage(damage);
        //         ai.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
        //         Debug.Log(ai.CurrentHealth);
        //     }
        // }

        GameObject projectile = Instantiate(bullet);
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), transform.GetComponentInChildren<Collider>());
        projectile.transform.position = transform.position;
        Vector3 rotation = projectile.transform.rotation.eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);

    }


}