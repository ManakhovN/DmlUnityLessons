using UnityEngine;
using System.Collections;

public class RightSprite : MonoBehaviour {
    public float speed;
    public Vector3 way;
    public float lifeTime;

	public virtual float Move () {
        lifeTime -= Time.deltaTime;
        transform.position += way * speed * Time.deltaTime;
        return lifeTime;
	}

    public void ResetLifeTime(float lifeTime)
    {
        this.lifeTime = lifeTime;
    }
}
