using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableInteractable : Interactable
{
    public bool isStored = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interaction()
    {
        Debug.Log("Interactuando...");
        if (player && !isStored)
        {
            isStored = true;
            GameObject slot = GameObject.Find("Slot");
            transform.position = slot.transform.position;
            transform.SetParent(slot.gameObject.transform);
        }
    }
}
