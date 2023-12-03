using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HealBehaviour : Behaviour {
    
    private EnemyController controller;

    public HealBehaviour(EnemyController controller) {
        this.controller = controller;
    }

    public override void Update() {
        controller.CurrentHealth += controller.HealingRate;
    }
}
