using UnityEngine;

public class PatrolPoint : MonoBehaviour {
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, .3f);
    }

}