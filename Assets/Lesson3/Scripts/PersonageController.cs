using UnityEngine;
using System.Collections;

public class PersonageController : MonoBehaviour {
    public float movingSpeed = 1f;
    Rigidbody2D rigidBody;
    public bool isFlying = true;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    Vector2 movingVector = Vector2.zero;
    void FixedUpdate()
    {
        movingVector.x = Time.fixedDeltaTime * movingSpeed * Input.GetAxis("Horizontal");
        if (!isFlying)
        {
            if (movingVector.x > 0)
            {
                animator.SetTrigger("Run");
                spriteRenderer.flipX = false;
            }
            else
            if (movingVector.x < 0)
            {
                animator.SetTrigger("Run");
                spriteRenderer.flipX = true;
            }
            else
                animator.SetTrigger("Stop");            
        }
        animator.SetBool("isFlying", isFlying);
        if (!isFlying && Input.GetKeyDown(KeyCode.Space))
        {
            movingVector.y = 440f;
        }
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
            {
                isFlying = false;
            }
        }
    }
}
