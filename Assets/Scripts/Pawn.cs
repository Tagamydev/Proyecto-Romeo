using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : Enemy
{	
    public override bool CheckMove()
    {
        // Lógica específica de movimiento en forma de "L" como en ajedrez
        Debug.Log(gameObject.name + ": Buscando jugador...");
        return (false);
    }

    public void Promote()
    {
        // Lógica para convertir el peón en otra pieza (por ejemplo, Reina)
        Debug.Log("El Peón ha sido promovido");
    }
}
