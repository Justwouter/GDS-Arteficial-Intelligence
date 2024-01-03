using System.Linq;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class SelectedAgentPatroller : UIElement {
    [SerializeField] private TMP_InputField agentNameText;
    [SerializeField] private TMP_Dropdown point1;
    [SerializeField] private TMP_Dropdown point2;
    [SerializeField] private Button confirmButton;
    private bool firstUpdate = false;
    private GameObject selectedObject;

    private void OnDisable() {
        firstUpdate = false;
    }

    private void Update() {
        if (gameManager != null) {
            agentNameText.text = gameManager.SelectedAgent.name;
            UpdateUI();
            if (!firstUpdate | selectedObject != gameManager.SelectedAgent) {
                point1.value = gameManager.PatrolPoints.IndexOf(gameManager.SelectedAgent.GetComponent<ABehaviour>().GetRoute()[0]);
                point2.value = gameManager.PatrolPoints.IndexOf(gameManager.SelectedAgent.GetComponent<ABehaviour>().GetRoute()[1]);
                firstUpdate = true;
                selectedObject = gameManager.SelectedAgent;
            }

        }
    }

    public void UpdateUI() {
        point1.options.Clear();
        point2.options.Clear();
        for (int i = 0; i < gameManager.PatrolPoints.Count; i++) {
            point1.options.Add(new TMP_Dropdown.OptionData(gameManager.PatrolPoints[i].name));
            point2.options.Add(new TMP_Dropdown.OptionData(gameManager.PatrolPoints[i].name));
            
        }


    }

    public void OnConfirmButtonClicked() {
        gameManager.SelectedAgent.GetComponent<ABehaviour>().SetRoute(new PatrolPoint[] { gameManager.PatrolPoints[point1.value], gameManager.PatrolPoints[point2.value] });
        gameManager.SelectedAgent.GetComponent<ABehaviour>().ToggleEnabled();
        gameManager.SelectedAgent = null;
    }

    public void OnNameChange() {
        gameManager.SelectedAgent.name = agentNameText.text;
    }
}