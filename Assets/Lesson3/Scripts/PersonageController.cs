using UnityEngine;
using System.Collections;

public class PersonageController : MonoBehaviour {
    public float movingSpeed = 1f;
    Rigidbody2D rigidBody;
    public bool isFlying = true;
    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    Vector2 movingVector = Vector2.zero;
    void FixedUpdate()
    {
        movingVector.x = Time.fixedDeltaTime * movingSpeed * Input.GetAxis("Horizontal");
        if (!isFlying && Input.GetKeyDown(KeyCode.Space))
            movingVector.y = 400f;
        else movingVector.y = 0f;
        rigidBody.AddForce(movingVector, ForceMode2D.Force);
        isFlying = true;
    }

    void OnCollisionStay2D(Collision2D coll) {
        if (coll.contacts.Length > 1)
        {
            Vector2 collisionPosition = transform.InverseTransformPoint(coll.contacts[0].point);
            Vector2 collisionPosition2 = transform.InverseTransformPoint(coll.contacts[1].point);
            if (collisionPosition.y == collisionPosition2.y)
                isFlying = false;
        }
    }
}
