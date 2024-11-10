using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Array público de GameObject que representa el camino del enemigo
    public GameObject[] path;
    public int i = -1;
    private PlayerController playerController;
    public float moveDuration = 1f;  // Duración del movimiento entre puntos en segundos
    private bool isMoving = false;   // Bandera para verificar si el enemigo está en movimiento

    void Start()
    {
        Debug.Log("Path length: " + path.Length);

        // Busca el objeto PlayerController en la escena
        playerController = FindObjectOfType<PlayerController>();

        // Asegúrate de que se encontró el PlayerController
        if (playerController != null)
        {
            // Suscribirse al evento OnMoveEnemies
            playerController.OnMoveEnemies += Move;
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
        else if (!isMoving)  // Solo inicia un nuevo movimiento si no está en movimiento
        {
            i++;
            int pos = i % path.Length;
            Debug.Log("Indice: " + i + ", Longitud: " + path.Length + ", Posicion: " + pos);

            // Inicia el movimiento suave hacia el siguiente punto
            StartCoroutine(MoveToPosition(path[pos].transform.position, moveDuration));
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        isMoving = true;  // Marca que el enemigo está en movimiento
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        // Interpolación suave desde la posición inicial hasta la posición de destino
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegura que el enemigo esté exactamente en la posición objetivo al finalizar
        transform.position = targetPosition;
        isMoving = false;  // Marca que el movimiento ha terminado
    }
}
