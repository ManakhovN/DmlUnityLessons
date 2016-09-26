using UnityEngine;
using System.Collections;

public class PersonageController : MonoBehaviour {
    public float movingSpeed = 1f;
    Rigidbody2D rigidBody;
    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    Vector2 movingVector = Vector2.zero;
    void FixedUpdate()
    {
        movingVector.x = Time.fixedDeltaTime * movingSpeed * Input.GetAxis("Horizontal");
        rigidBody.AddForce(movingVector, ForceMode2D.Force);
    }
}
