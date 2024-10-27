using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject player;

    public abstract void Interaction();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrando en trigger con: " + other.gameObject.name);
        player = other.gameObject;
        player.GetComponent<PlayerController>().object_usable = gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Saliste del trigger con: " + other.gameObject.name);
        player.GetComponent<PlayerController>().object_usable = null;
        player = null;
    }
}
