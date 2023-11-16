using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class StateManager : MonoBehaviour
{
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        var player = FindObjectsOfType<Symbol>().ToList().First(symbol => symbol.IsPlayer);
        currentState = new IdleState(player.transform, GetComponent<NavMeshAgent>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
