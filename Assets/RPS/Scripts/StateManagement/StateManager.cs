using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class StateManager : MonoBehaviour
{
    State currentState;

    void Start()
    {
        var player = FindObjectsOfType<Symbol>().ToList().First(symbol => symbol.IsPlayer);
        currentState = new IdleState(player, GetComponent<NavMeshAgent>());
        currentState.InitState();

        Debug.Log(player);
    }

    void Update()
    {
        currentState.Update();
        var newState = currentState.TryToGetNewState();
        if (newState == null)
            return;

        currentState = newState;
        currentState.InitState();
    }
}
