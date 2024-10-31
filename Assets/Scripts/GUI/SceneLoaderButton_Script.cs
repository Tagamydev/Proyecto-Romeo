using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderButton_Script : MonoBehaviour
{
	public	string		scene_name;

	public void	click()
	{
		SceneManager.LoadScene(scene_name, LoadSceneMode.Single);
	}
}
