using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowFps : MonoBehaviour {
    Text text;
    float deltaTime;
	void Start () {
        text = GetComponent<Text>();
	}

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        text.text = "FPS:" + (1f/deltaTime);
    }
}
