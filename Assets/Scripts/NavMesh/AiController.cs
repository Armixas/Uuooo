using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    [SerializeField]
    private AiState initialState;

    private ProjectileController projectileController;
    private TankController tankController;
    private NavMeshAgent navMeshAgent;

    private AiState currentAiState;
    private List<Player> players;

    private AiState CurrentAiState {
        get {
            if (currentAiState == null)
                currentAiState = initialState;
            return currentAiState;
        }
    }
    public NavMeshAgent NavMeshAgent { get {
            if (navMeshAgent == null)
                SetupNavMeshAgent();
            return navMeshAgent;
                    }
    }

    public float NextFireTime { get; set; }
    public Vector2 TargetAxis { get; set; }
    public IReadOnlyList<Player> Players => players;

    private void OnDrawGizmos()
    {
        CurrentAiState.UpdateStateGizmos(this);
    }

    private void SetupNavMeshAgent()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        projectileController = GetComponent<ProjectileController>();
        tankController = GetComponent<TankController>();
        players = FindObjectsOfType<Player>().ToList();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentAiState.UpdateState(this);
        tankController.Move(TargetAxis);
        UpdatePlayers();
    }
    public void ChangeState(AiState newAiState) 
    {
        currentAiState = newAiState;
    }

    public void Fire() 
    {
        projectileController.UpdateAmmo(1);
        projectileController.Fire();

    }

    private void UpdatePlayers()
    {
        for (int i = players.Count -1; i >= 0; i--)
        {
            var player = players[i];
            if (!player.enabled)
                players.Remove(player);
        }
    }
}
