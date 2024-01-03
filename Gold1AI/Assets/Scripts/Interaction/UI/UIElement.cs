using UnityEngine;

public abstract class UIElement : MonoBehaviour {
    protected GameManager gameManager;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Disable() {
        gameObject.SetActive(false);
    }
    public void Enable() {
        gameObject.SetActive(true);
    }
}