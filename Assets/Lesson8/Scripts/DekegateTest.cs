using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DekegateTest : MonoBehaviour {
    public delegate void TestDelegate();
    TestDelegate del;

    public void Start()
    {
        del = ShowByeMessage;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (del == ShowHelloMessage)
                del = ShowByeMessage;
            else
                del = ShowHelloMessage;
        }
        del();
    }

    public void ShowHelloMessage()
    {
        Debug.Log("HELLO");
    }

    public void ShowByeMessage()
    {
        Debug.Log("Bye");
    }
}
