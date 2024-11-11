using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Enemy
{
    public Transform player;
    public float moveSpeed = 5f;
    public float detectionRange = 10f;  // Distancia máxima que el enemigo puede ver al player
    private Vector3 targetPosition;
    private bool playerDetected = false;

    void Start()
    {
        
    }

    void Update()
	{
		DetectPlayer();
		if (playerDetected)
		{
			MoveTowardsPlayer();
		}
	}

	void DetectPlayer()
	{
		playerDetected = false;

		if (CheckDirection(Vector3.right) || CheckDirection(Vector3.left) || CheckDirection(Vector3.up) || CheckDirection(Vector3.down))
		{
			playerDetected = true;
		}
	}

	bool CheckDirection(Vector3 direction)
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, direction, out hit, detectionRange))
		{
			if (hit.transform == player)
			{
				targetPosition = hit.transform.position;
				return true;
			}
		}
		return false;
	}

	void MoveTowardsPlayer()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

		if (transform.position == targetPosition)
		{
			KillPlayer();
		}
	}

	void KillPlayer()
	{
		Debug.Log("Player killed!");
		//agregar logica para matarlo
	}

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
