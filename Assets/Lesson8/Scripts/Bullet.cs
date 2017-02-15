using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public KillableObject hitted;

    void OnCollisionEnter2D(Collision2D coll) {
        hitted = coll.transform.GetComponent<KillableObject>();
    }

    public void Refresh()
    {
        this.transform.position += transform.right * speed * Time.deltaTime;
    }
}
