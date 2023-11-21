using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{

    private SymbolEnum symbol;

    public SymbolEnum CurrentSymbol => symbol;

    [SerializeField]
    public bool IsPlayer;

    [SerializeField]
    private float changeInterval;

    [SerializeField]
    private MeshRenderer quad;

    [SerializeField]
    private List<Material> materials;

    // Start is called before the first frame update
    void Start()
    {
        ChangeSymbol(GetRandomSymbol());
        if (IsPlayer) {
            StartCoroutine(ChangeSymbolRoutine());
        }
    }

    IEnumerator ChangeSymbolRoutine() {
        while (true) {
            yield return new WaitForSeconds(changeInterval);
            ChangeSymbol(GetRandomSymbol());
        }
    }

    private SymbolEnum GetRandomSymbol() {
        int rand = Random.Range(0, System.Enum.GetValues(typeof(SymbolEnum)).Length);
        return (SymbolEnum) rand;
    }

    void ChangeSymbol(SymbolEnum newSymbol) {
        symbol = newSymbol;
        quad.material = materials[(int) symbol];
    }

    private void OnCollisionEnter(Collision collision) {
        if (!IsPlayer) return;

        var enemy = collision.gameObject.GetComponent<Symbol>();
        if (!enemy) return;

        var wouldWin = symbol.WouldWin(enemy.symbol);
        if (wouldWin.HasValue && wouldWin.Value) {
            Destroy(enemy.gameObject);
        }
    }
}

public enum SymbolEnum
{
    Rock,
    Paper,
    Scissors
}