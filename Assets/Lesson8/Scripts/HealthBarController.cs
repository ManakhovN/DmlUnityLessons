using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {
    public KillableObject killableObject;
    RectTransform child;
    void Start () {
        child = transform.GetChild(0).GetComponent<RectTransform>();
        killableObject.TakeDamageEvent += OnHealthChanged;
	}
    Vector2 zero = Vector2.zero;
    private void OnHealthChanged(KillableObject sender)
    {
        child.anchorMax = new Vector2(killableObject.health/killableObject.healthAtStart,1f);
        child.sizeDelta = zero;
    }
}
