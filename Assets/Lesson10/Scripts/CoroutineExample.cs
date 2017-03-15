using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineExample : MonoBehaviour {
    public Text text;
    void Start () {
        StartCoroutine(CountDown());
	}

    IEnumerator CountDown()
    {
        for (int i = 100; i >= 0; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
