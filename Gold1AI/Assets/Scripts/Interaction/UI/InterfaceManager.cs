using UnityEngine;

public class InterfaceManager : UIElement {
    [SerializeField] private AgentSpawnerSelector aSS;
    [SerializeField] private SelectedAgentPatroller sAP;
    [SerializeField] private SelectedAgentRegular sAR;

    private void Update() {
        if (gameManager.SelectedAgent != null) {
            if (gameManager.SelectedAgent.GetComponent<RegularBehaviour>()) {
                sAP.Disable();
                aSS.Disable();
                sAR.Enable();
                return;
            }
            else if (gameManager.SelectedAgent.GetComponent<PatrolBehaviour>()) {
                sAR.Disable();
                aSS.Disable();
                sAP.Enable();
                return;
            }
        }
        sAR.Disable();
        sAP.Disable();
        aSS.Enable();
    }

}