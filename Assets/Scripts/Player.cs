using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public	GameObject	object_usable;

    public float moveSpeed =5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    float moveX = Input.GetAxis("Horizontal");
	    float moveY = Input.GetAxis("Vertical");
	    
	    Vector3 movement = new Vector3(moveX, 0f, moveY)*moveSpeed* Time.deltaTime  ;
	    transform.Translate(movement);

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("FIRE!");
            if (object_usable)
            {
                object_usable.GetComponent<Interactable>().Interaction();
            }
        }
    }
}
