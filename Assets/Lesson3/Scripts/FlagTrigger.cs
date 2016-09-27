using UnityEngine;
using System.Collections;

public class FlagTrigger : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        spriteRenderer.sprite = sprites[1];
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        spriteRenderer.sprite = sprites[0];
    }
}
