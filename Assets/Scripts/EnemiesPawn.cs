using UnityEngine;

public class Pawn : Enemy
{
	public override void Move()
	{
		// Lógica específica de movimiento de un peón
		Debug.Log("Movimiento de un casillero para el Peón");
	}
	
	public void Promote()
	{
		// Lógica para convertir el peón en otra pieza (por ejemplo, Reina)
		Debug.Log("El Peón ha sido promovido");
	}
}
