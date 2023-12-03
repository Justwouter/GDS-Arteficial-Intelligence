using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float MaxHealth;
    public float CurrentHealth {
        get { return CurrentHealth; }
        set {if (CurrentHealth + value <= MaxHealth) {
                CurrentHealth += value;}
            else {
                CurrentHealth = MaxHealth;}}
    }
    public float HealingRate;

    public Behaviour CurrentBehaviour;

    private void Update() {
        CurrentBehaviour.Update();
    }

}