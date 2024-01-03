using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class AgentSpawnerSelector : UIElement {
    [SerializeField] private TextMeshProUGUI agentNameText;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    
    private int currentAgentIndex = 0;

    
    private void Update() {
        UpdateSelectedAgent();
    }

    public void OnNextButtonClicked() {
        if(currentAgentIndex+1 > gameManager.AgentPrefabs.Count-1){
            currentAgentIndex = 0;
        }
        else{
            currentAgentIndex++;
        }
    }

    public void OnPrevButtonClicked() {
        if(currentAgentIndex == 0){
            currentAgentIndex = gameManager.AgentPrefabs.Count-1;
        }
        else{
            currentAgentIndex--;
        }
    }

    private void UpdateSelectedAgent() {
        agentNameText.text = gameManager.AgentPrefabs[currentAgentIndex].name;
        gameManager.CurrentAgentPrefab = gameManager.AgentPrefabs[currentAgentIndex];
    }


    

}