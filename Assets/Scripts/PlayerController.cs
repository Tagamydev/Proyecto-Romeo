using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public	GameObject object_usable;

    // Métodos del delegado
    public delegate void MoveEnemiesHandler();
    public event MoveEnemiesHandler OnMoveEnemies;

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
        // Mueve gameObject a la posición designada
        transform.position = targetPosition;
        // Invoca el movimiento de los enemigos
        OnMoveEnemies?.Invoke();
    }
}
