using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    public override bool CheckMove()
    {
        // Lógica específica de movimiento en forma de "L" como en ajedrez
        Debug.Log(gameObject.name + ": Buscando jugador...");
        return (false);
    }
}
