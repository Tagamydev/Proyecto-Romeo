using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject object_usable;

    // M�todos del delegado
    public delegate void MoveEnemiesHandler();
    public event MoveEnemiesHandler OnMoveEnemies;
    public float moveTime;

    private bool isMoving = false;  // Para asegurar que no se interrumpa el movimiento

    private void Start()
    {
    }

    private void Update()
    {
        /* Comprobaci�n personalizada del objeto hijo clicado */
        if (Input.GetMouseButtonDown(0))  // 0 = bot�n izquierdo del rat�n
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Lanza el raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica si el objeto clicado tiene el script ChildClickNotifier
                ChildClickNotifier child = hit.collider.GetComponent<ChildClickNotifier>();
                if (child != null)
                {
                    // Llama al m�todo en el padre
                    OnChildClicked(child);
                }
            }
        }
    }

    public void OnChildClicked(ChildClickNotifier child)
    {
        // Guarda la posici�n del hijo
        Vector3 targetPosition = child.transform.position;
        Debug.Log("El hijo " + child.gameObject.name + " en la posici�n " + targetPosition + " ha sido clicado.");

        // Inicia el movimiento suave hacia la posici�n objetivo
        if (!isMoving)
        {
            StartCoroutine(MoveToTarget(targetPosition, moveTime));  // Tiempo de 1 segundo
        }
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition, float duration)
    {
        isMoving = true;  // Marca que el objeto est� en movimiento
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Interpola suavemente desde la posici�n inicial a la posici�n de destino
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegura que llegue exactamente al destino
        transform.position = targetPosition;
        isMoving = false;  // Marca que el movimiento ha terminado

        // Invoca el movimiento de los enemigos al llegar al destino
        OnMoveEnemies?.Invoke();
    }
}
