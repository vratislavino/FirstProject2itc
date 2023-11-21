using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    Vector3 targetPoint;

    public IdleState(Symbol player, NavMeshAgent agent) : base(player, agent) {
    }

    public override void InitState() {
        GenerateTarget();
    }

    private void GenerateTarget() {
        targetPoint = new Vector3(Random.Range(0f, 100f), 60f, Random.Range(0f, 100f));
        // jak vygenerovat point na terénu?


        if (Physics.Raycast(targetPoint, Vector3.down, out RaycastHit info, 100)) {
            targetPoint = info.point;
            //Debug.Log(info.point);
        }


        //Debug nástroje pro testování
        //Debug.DrawLine(targetPoint, targetPoint + Vector3.down * 100, Color.red, 10);
        //GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //g.transform.position = targetPoint;
    }

    public override void Update() {
        
        agent.SetDestination(targetPoint);
        
        var targetCheck = targetPoint;
        var enemyCheck = agent.transform.position;
        targetCheck.y = enemyCheck.y = 0;

        if (Vector3.Distance(targetCheck, enemyCheck) < 1) {
            GenerateTarget();
        }
    }

    public override State TryToGetNewState() {
        if(Vector3.Distance(agent.transform.position, playerSymbol.transform.position) < 15f) {
            
            // player symbol / this symbol -> flee state / attack state
            bool? wouldWin = thisSymbol.CurrentSymbol.WouldWin(playerSymbol.CurrentSymbol);

            if(wouldWin.HasValue) {
                if(wouldWin.Value == true) {
                    return new AttackState(playerSymbol, agent);
                } else {
                    return new FleeState(playerSymbol, agent);
                }
            } else {
                return null;
            }
        }
        return null;
    }
}
