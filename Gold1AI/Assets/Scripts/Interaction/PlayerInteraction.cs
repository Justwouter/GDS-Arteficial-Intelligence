using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] private GameObject[] agentList;
    [SerializeField] private GameObject chosenAgent;
    [SerializeField] private LayerMask agentLayer;
    [SerializeField] private LayerMask floorLayer;
    private ABehaviour selectedObject;


    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check for agent hits
            if (Physics.Raycast(ray, out RaycastHit hit, 1000, agentLayer)) {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.TryGetComponent<ABehaviour>(out ABehaviour behaviour)) {
                    HandleAgentSelected(behaviour);
                }
            }

            // Check for floor hits
            else if (Physics.Raycast(ray, out hit, 1000, floorLayer)) {
                Debug.Log(hit.transform.gameObject.name);
                HandleNoneSelected();
            }

        }
    }

    public void HandleAgentSelected(ABehaviour behaviour) {
        Debug.Log("I WORK! Blood for the Blood god! Skulls for the skull throne");
        behaviour.ToggleEnabled();
        selectedObject = behaviour;
    }

    public void HandleNoneSelected(){
        selectedObject = null;
    }

    public ABehaviour GetSelectedObject(){
        return selectedObject;
    }
}
