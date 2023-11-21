using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent agent;

    protected Symbol playerSymbol;
    protected Symbol thisSymbol;

    public State(Symbol player, NavMeshAgent agent) {
        this.playerSymbol = player;
        this.agent = agent;
        thisSymbol = agent.GetComponent<Symbol>();
    }

    public abstract void InitState();

    public abstract void Update();

    public abstract State TryToGetNewState();
}
