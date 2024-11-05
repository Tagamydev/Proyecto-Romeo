using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
	// Array publico de game object
	public GameObject[] path;
    public int i = -1;

    private PlayerController playerController;

    void Start()
    {
        Debug.Log("PAth:" + path.Length);
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

    public abstract bool CheckMove();

    // Función común a todos los enemigos
    public virtual void Die()
	{
		// sonido?
		Debug.Log("El enemigo ha muerto");
        playerController.OnMoveEnemies -= Move;
        Destroy(gameObject);
	}
	
	public virtual void Move()
    {
        if (CheckMove())
        {
            Debug.Log("Jugador fijado!");
        }
        else
        {
            i++;
            int pos = i % path.Length;
            Debug.Log("Indice: " + i + ", Longitud: " + path.Length + ", Posicion: " + pos);
            transform.position = path[pos].transform.position;
        }
    }
}
