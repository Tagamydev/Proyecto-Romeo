using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegates_Test_Script : MonoBehaviour
{
	public delegate void MyDelegate();
	public static event MyDelegate printEvent;
	// Start is called before the first frame update
	//
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			printEvent?.Invoke();
		}
		
	}
}
