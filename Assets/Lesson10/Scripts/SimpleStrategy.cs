using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rotate", menuName = "ScriptableObjects/Rotate")]
public class SimpleStrategy : ScriptableObject {
    public float speed = 5f;
    public virtual void Move(Transform t)
    {
        t.transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
