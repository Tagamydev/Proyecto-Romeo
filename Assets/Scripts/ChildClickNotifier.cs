using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildClickNotifier : MonoBehaviour
{
    // Referencia al script del padre
    public PlayerController parent;
    public MeshRenderer meshRenderer;

    void Start()
    {
        // Captura del MeshRender del propio objeto
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogWarning("No se encontró el MeshRenderer en este objeto.");
        }
    }

    private void OnMouseDown()
    {
        // Notificar al padre cuando este hijo es clicado
        parent.OnChildClicked(this);
    }

    // Control de colisiones
    public void OnTriggerEnter(Collider other)
    {
        meshRenderer.enabled = false;
    }

    public void OnTriggerExit(Collider other)
    {
        meshRenderer.enabled = true;
    }


}
