using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    public AttackState(Symbol player, NavMeshAgent agent) : base(player, agent) {
    }

    public override void InitState() { }

    public override void Update() {
        agent.SetDestination(playerSymbol.transform.position);
    }

    public override State TryToGetNewState() {
        if (Vector3.Distance(agent.transform.position, playerSymbol.transform.position) > 15f)
            return new IdleState(playerSymbol, agent);

        var wouldWin = thisSymbol.CurrentSymbol.WouldWin(playerSymbol.CurrentSymbol);
        if (!wouldWin.HasValue) {
            return new IdleState(playerSymbol, agent);
        } else {
            if(wouldWin.Value) {
                return null;
            } else {
                return new FleeState(playerSymbol, agent);
            }
        }
    }

}
