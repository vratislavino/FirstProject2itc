using UnityEngine;
using UnityEngine.AI;

public class FleeState : State
{
    public FleeState(Symbol player, NavMeshAgent agent) : base(player, agent) {
    }

    public override void InitState() { }

    public override void Update() {

        var dir = playerSymbol.transform.position - agent.transform.position;

        agent.SetDestination(agent.transform.position - dir.normalized);

    }

    public override State TryToGetNewState() {
        
        if (Vector3.Distance(agent.transform.position, playerSymbol.transform.position) > 15f)
            return new IdleState(playerSymbol, agent);

        var wouldWin = thisSymbol.CurrentSymbol.WouldWin(playerSymbol.CurrentSymbol);
        if (!wouldWin.HasValue) {
            return new IdleState(playerSymbol, agent);
        } else {
            if (wouldWin.Value) {
                return new AttackState(playerSymbol, agent);
            } else {
                return null;
            }
        }
    }
}
