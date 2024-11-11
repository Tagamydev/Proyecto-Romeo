using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : Enemy
{
	// Start is called before the first frame update
	private bool CastRay(Vector3 direction, float range)
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, direction, out hit, range))
		{
			// Verifica si el rayo golpea al jugador
			Debug.Log("Colision con: " + hit.collider.gameObject.name);
			if (hit.collider.CompareTag("Player"))
			{
				hit.collider.gameObject.GetComponent<PlayerController>().Win();
				return hit.collider.gameObject == playerController.gameObject;
			}
		}
		return false;
	}

	private void Update()
	{
		Debug.DrawRay(gameObject.transform.position, Quaternion.Euler(0, -45, 0) * transform.up * 1.0f, Color.red);
		Debug.DrawRay(gameObject.transform.position, Quaternion.Euler(0, 45, 0) * transform.up, Color.blue);
	}

	public override bool CheckMove()
	{
		if (playerController == null)
		{
			Debug.LogWarning("PlayerController no encontrado, no se puede verificar con el rayo.");
			return false;
		}
		// Rango máximo de detección del rayo
		float detectionRange = 100.0f;
		// Calcula la dirección frontal del Pawn
		Vector3 forward = transform.up;
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
		Debug.Log("El Meta ha sido promovido");
	}
}
