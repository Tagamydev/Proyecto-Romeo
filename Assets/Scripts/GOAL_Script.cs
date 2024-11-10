using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOAL_Script : MonoBehaviour
{
	public	string	scene_name;
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
        if (other.CompareTag("Player"))
	{
		print("OK SE HA TRIGEREADO");
		SceneManager.LoadScene(scene_name, LoadSceneMode.Single);
		
	}
    }
	
}
