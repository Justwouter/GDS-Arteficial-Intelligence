using TMPro;

using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private PlayerInteraction interaction;

    private void Update() {
        if (interaction.GetSelectedObject() != null) {
            nameField.SetText(interaction.GetSelectedObject().name);
        }
        else {

        }
    }

    private void ToggleSelectionWindows(){
        
    }
}