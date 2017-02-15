using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillableObject : MonoBehaviour {
    public float health = 100f;
    public float healthAtStart = 100f;
    public bool isDead = false;

    public delegate void TakeDamageEventHandler(KillableObject sender);

    public event TakeDamageEventHandler TakeDamageEvent;
    public UnityEvent uEvent;

    public void TakeDamage(float delta)
    {
        health -= delta;
        if (TakeDamageEvent!=null)
            TakeDamageEvent(this);

        if (health < 0)
            Destroy(this.gameObject);

        uEvent.Invoke();
    }

    public virtual void Reset()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        health = healthAtStart;
        isDead = false;
    }

    public void SetHealth(float h)
    {
        health = h;
    }

    public virtual void Refresh()
    {
    }


}
