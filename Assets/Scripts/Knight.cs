using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
	public override void Move()
	{
		// Lógica específica de movimiento en forma de "L" como en ajedrez
		Debug.Log("Movimiento en L para el Caballo");
	}

    public override void CheckMove()
    {
        // Lógica específica de movimiento en forma de "L" como en ajedrez
        Debug.Log("Comprobacion");
    }
}
