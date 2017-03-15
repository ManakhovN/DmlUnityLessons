using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "change time", menuName = "abc/change time")]
public class ExampleClass : ScriptableObject{

    public Text text;
    public int startNumber;
    public void RunChangeTime(Text t, MonoBehaviour mb)
    {
        text = t;
        mb.StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        for (int i = startNumber; i >= 0; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
