using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class SelectedAgentRegular : UIElement {
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_InputField agentNameText;
    [SerializeField] private TextMeshProUGUI cordsText;
    [SerializeField] private LayerMask floorLayer;
    private bool firstUpdate = false;
    private GameObject selectedObject;

    private void OnDisable() {
        firstUpdate = false;
    }

    private void Update() {
        if (gameManager != null) {
            agentNameText.text = gameManager.SelectedAgent.name;

            if (!firstUpdate | selectedObject != gameManager.SelectedAgent) {
                cordsText.text = FormatVectorToString(gameManager.SelectedAgent.transform.position);

                firstUpdate = true;
                selectedObject = gameManager.SelectedAgent;
            }

            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000, floorLayer)) {
                    gameManager.SelectedAgent.GetComponent<ABehaviour>().SetEnabled();
                    gameManager.SelectedAgent.GetComponent<ABehaviour>().SetTarget(hit.point);
                }
            }

        }
    }

    public void OnConfirmButtonClicked() {
        gameManager.SelectedAgent = null;
    }

    public void OnNameChange() {
        gameManager.SelectedAgent.name = agentNameText.text;
    }
    private string FormatVectorToString(Vector3 vector) {
        return $"({vector.x}, {vector.z})";
    }
}