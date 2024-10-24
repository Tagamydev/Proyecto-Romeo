using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scrip_SceneLoaderButton_0 : MonoBehaviour
{
	public	GameObject	scene;
	public	string		scene_name;
	// Start is called before the first frame update
	void Start()
	{
	    
	}

	// Update is called once per frame
	void Update()
	{
	    
	}


	public void	click()
	{
		SceneManager.LoadScene(scene_name, LoadSceneMode.Single);
	}
}
