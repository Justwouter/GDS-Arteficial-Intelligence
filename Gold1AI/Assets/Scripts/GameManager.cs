using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class GameManager : MonoBehaviour {
    public InterfaceManager InterfaceManager;
    public List<PatrolPoint> PatrolPoints = new();
    public List<GameObject> AgentPrefabs = new();

    public GameObject CurrentAgentPrefab;

    public GameObject SelectedAgent;

    private void Start() {
        PatrolPoints = FindObjectsOfType<PatrolPoint>().ToList();
        InterfaceManager = FindAnyObjectByType<InterfaceManager>();
    }
    
}