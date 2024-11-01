using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	// Función común a todos los enemigos
	public virtual void Die()
	{
		// sonido?
		Debug.Log("El enemigo ha muerto");
		Destroy(gameObject);
	}
	
	// Método abstracto para el movimiento específico
	public abstract void Move();
}
