using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Enemy
{
	public override void Move()
	{
		// Lógica específica de movimiento en línea recta
		Debug.Log("Movimiento en línea recta para la Torre");
	}
	public void Castle()
	{
		// Lógica para convertir el enroque con el rey si al final lo hacemos
		Debug.Log("Movimiento para el enroque");
	}
}
