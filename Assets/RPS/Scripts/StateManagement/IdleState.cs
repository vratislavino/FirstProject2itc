using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    Vector3 targetPoint;

    public IdleState(Transform player, NavMeshAgent agent) : base(player, agent) {
    }

    public override void InitState() {
        GenerateTarget();
    }

    private void GenerateTarget() {
        targetPoint = new Vector3(Random.Range(0f, 100f), 0f, Random.Range(0f, 100f));
    }

    public override void Update() {
        agent.SetDestination(targetPoint);
        if(Vector3.Distance(targetPoint, agent.transform.position) < 1) {
            GenerateTarget();
        }
    }

    public override State TryToGetNewState() {
        return null;
    }
}
