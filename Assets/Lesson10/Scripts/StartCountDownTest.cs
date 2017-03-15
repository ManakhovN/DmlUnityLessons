using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountDownTest : MonoBehaviour {
    public ExampleClass countDown;
    public Text text;
    void Start () {
        countDown.RunChangeTime(text, this);
	}
	
}
