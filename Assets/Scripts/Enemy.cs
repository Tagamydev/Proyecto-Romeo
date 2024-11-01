using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
	// Array publico de game object
	public GameObject[] path;

	// Función común a todos los enemigos
	public virtual void Die()
	{
		// sonido?
		Debug.Log("El enemigo ha muerto");
		Destroy(gameObject);
	}
	
	// Método abstracto para el movimiento específico
	public abstract void Move();

	// Método abstracto para el movimiento específico
	public abstract void CheckMove();

}
