using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Enemy
{
    public override bool CheckMove()
    {
        // Lógica específica de movimiento en forma de "L" como en ajedrez
        Debug.Log(gameObject.name + ": Buscando jugador...");
        return (false);
    }

    public void Castle()
	{
		// Lógica para convertir el enroque con el rey si al final lo hacemos
		Debug.Log("Movimiento para el enroque");
	}
}
