using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public delegate void EnemyState();
    EnemyState currentState;

    void Start () {
        currentState = Run;
	}

    void Update() {
        currentState();
	}

    public void Walk()
    {
        transform.position += Vector3.left * 2f * Time.deltaTime;
        if (transform.position.x < -4f)
            currentState = Stay;
    }

    public void Run()
    {
        transform.position += Vector3.left * 4f * Time.deltaTime;
        if (transform.position.x < -4f)
            currentState = Stay;
        if (transform.position.x < 0f)
            currentState = Walk;
    }

    public void Stay(){
    }
}
