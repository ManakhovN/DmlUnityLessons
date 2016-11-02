using UnityEngine;
using System.Collections;

public class JustSpawner : MonoBehaviour {
    public GameObject Prefab;
    public float deltaTime = 2f;
    float timer = 2f;
	void Start () {
        timer = deltaTime;
 	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Instantiate(Prefab);
            timer = deltaTime;
        }
	}
}
