using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour {

    public KillableObject klObj;
    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        klObj.TakeDamageEvent += RefreshView;
	}

    private void RefreshView(KillableObject sender)
    {
        text.text = "Health = "+klObj.health;
    }
}
