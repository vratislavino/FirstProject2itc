using UnityEngine;
using UnityEngine.AI;

public abstract class State
{

    protected Transform playerReference;
    protected NavMeshAgent agent;

    public State(Transform player, NavMeshAgent agent) {
        this.playerReference = player;
        this.agent = agent;
    }

    public abstract void InitState();

    public abstract void Update();

    public abstract State TryToGetNewState();
}
