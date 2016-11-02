using UnityEngine;
using System.Collections;

public class RotateSprite : RightSprite {
    public override float Move()
    {
        transform.Rotate(0, 0, 10f*Time.deltaTime * speed);
        return base.Move();
    }
}
