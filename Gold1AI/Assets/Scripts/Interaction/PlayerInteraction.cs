using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.AI;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] private LayerMask agentLayer;
    [SerializeField] private LayerMask floorLayer;

    private GameManager gameManager;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        if (!gameManager.InSelectionMode) {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Check for agent hits
                if (Physics.Raycast(ray, out RaycastHit hit, 1000, agentLayer)) {
                    Debug.Log(hit.transform.gameObject.name);
                    if (hit.transform.gameObject.TryGetComponent<ABehaviour>(out ABehaviour behaviour)) {

                        if (gameManager.SelectedAgent != null) {
                            HandleAgentSelected();
                        }
                        if (gameManager.SelectedAgent == behaviour.gameObject) {
                            gameManager.SelectedAgent = null;
                            return;
                        }
                        gameManager.SelectedAgent = behaviour.gameObject;
                        HandleAgentSelected();
                    }
                }

                // Check for floor hits
                else if (Physics.Raycast(ray, out hit, 1000, floorLayer)) {
                    Debug.Log(hit.transform.gameObject.name);
                    //gameManager.SelectedAgent = null;
                }

            }
            if (Input.GetMouseButtonDown(1) && gameManager.SelectedAgent == null) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000, floorLayer)) {
                    Debug.Log(hit.point);

                    GameObject newAgent = Instantiate<GameObject>(gameManager.CurrentAgentPrefab);
                    newAgent.GetComponent<NavMeshAgent>().Warp(new(hit.point.x, 1.6f, hit.point.z));
                    newAgent.GetComponent<ABehaviour>().SetRoute(gameManager.PatrolPoints.Where(p => p.GetPatrolNetStatus()).ToArray());
                }
            }
        }
    }

    public void HandleAgentSelected() {
        gameManager.SelectedAgent.GetComponent<ABehaviour>().ToggleEnabled();
    }
}
