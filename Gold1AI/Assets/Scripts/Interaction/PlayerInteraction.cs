using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] private GameObject[] agentList;
    void Start() {

    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000)) {
                Debug.Log(hit.transform.gameObject.name);
            }

        }
    }
}
