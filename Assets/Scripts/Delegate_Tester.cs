using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate_Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
	Delegates_Test_Script.printEvent += test;
    }


    void test()
    {
	print("hello samu1!!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
