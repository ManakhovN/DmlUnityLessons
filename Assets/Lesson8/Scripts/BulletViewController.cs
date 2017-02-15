using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletViewController : MonoBehaviour {
    public Shotgun shotgun;
    Text text;
	void Start () {
        if (shotgun == null)
            shotgun = GameObject.FindObjectOfType<Shotgun>();
        text = GetComponent<Text>();
        OnBulletNumChanged(shotgun);
        shotgun.BulletNumChanged += OnBulletNumChanged;
	}

    private void OnBulletNumChanged(Shotgun sender)
    {
        text.text = shotgun.currentBulletsCount + "/" + shotgun.maxBulletsCount;
    }
}
