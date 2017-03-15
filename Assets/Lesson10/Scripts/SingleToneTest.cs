using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleToneTest : MonoBehaviour {
    public ScriptableObjectSingleton obj;
    public void Start()
    {
        obj = ScriptableObjectSingleton.Instance;
    }
}
