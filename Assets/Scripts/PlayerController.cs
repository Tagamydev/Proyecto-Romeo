using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject object_usable;

    // Métodos del delegado
    public delegate void MoveEnemiesHandler();
    public event MoveEnemiesHandler OnMoveEnemies;
    public float moveTime;

    private bool isMoving = false;  // Para asegurar que no se interrumpa el movimiento

    private void Start()
    {
    }

    private void Update()
    {
        /* Comprobación personalizada del objeto hijo clicado */
        if (Input.GetMouseButtonDown(0))  // 0 = botón izquierdo del ratón
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
                    // Llama al método en el padre
                    OnChildClicked(child);
                }
            }
        }
    }

    public void OnChildClicked(ChildClickNotifier child)
    {
        // Guarda la posición del hijo
        Vector3 targetPosition = child.transform.position;
        Debug.Log("El hijo " + child.gameObject.name + " en la posición " + targetPosition + " ha sido clicado.");

        // Inicia el movimiento suave hacia la posición objetivo
        if (!isMoving)
        {
            StartCoroutine(MoveToTarget(targetPosition, moveTime));  // Tiempo de 1 segundo
        }
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition, float duration)
    {
        isMoving = true;  // Marca que el objeto está en movimiento
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Interpola suavemente desde la posición inicial a la posición de destino
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
