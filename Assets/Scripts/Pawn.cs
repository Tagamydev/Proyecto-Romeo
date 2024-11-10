using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : Enemy
{	
	private bool CastRay(Vector3 direction, float range)
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, direction, out hit, range))
		{
			// Verifica si el rayo golpea al jugador
			return hit.collider.gameObject == playerController.gameObject;
		}
		return false;
	}
	public override bool CheckMove()
	{
		if (playerController == null)
		{
			Debug.LogWarning("PlayerController no encontrado, no se puede verificar con el rayo.");
			return false;
		}
		// Rango máximo de detección del rayo
		float detectionRange = 10.0f;
		// Calcula la dirección frontal del Pawn
		Vector3 forward = transform.forward;
		// Direcciones diagonales: 45 grados a la izquierda y 45 grados a la derecha
		Vector3 diagonalLeft = Quaternion.Euler(0, -45, 0) * forward;
		Vector3 diagonalRight = Quaternion.Euler(0, 45, 0) * forward;
		// Lanza el rayo en la dirección diagonal izquierda
		if (CastRay(diagonalLeft, detectionRange))
		{
			Debug.Log(gameObject.name + ": Jugador detectado en la diagonal izquierda.");
			return true;
		}
		// Lanza el rayo en la dirección diagonal derecha
		if (CastRay(diagonalRight, detectionRange))
		{
			Debug.Log(gameObject.name + ": Jugador detectado en la diagonal derecha.");
			return true;
		}
		Debug.Log(gameObject.name + ": Jugador no detectado en ninguna diagonal.");
		return false;
	}
	public void Promote()
	{
		// Lógica para convertir el peón en otra pieza (por ejemplo, Reina)
		Debug.Log("El Peón ha sido promovido");
	}
}
