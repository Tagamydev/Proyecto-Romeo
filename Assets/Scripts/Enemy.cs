using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
	// Array publico de game object
	public GameObject[] path;

    private PlayerController playerController;

    void Start()
    {
        // Busca el objeto PlayerController en la escena
        playerController = FindObjectOfType<PlayerController>();

        // Asegúrate de que se encontró el PlayerController
        if (playerController != null)
        {
            // Suscribirse al evento OnMoveEnemies
            playerController.OnMoveEnemies += Move; // Suscribe el método Move al evento
        }
        else
        {
            Debug.LogWarning("No se encontró PlayerController en la escena.");
        }
    }

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
