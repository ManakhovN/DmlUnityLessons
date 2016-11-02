using UnityEngine;
using System.Collections;

public class JustSprite : MonoBehaviour {
    Vector3 way;
    public float speed;
    public float lifeTime = 5f;
	void Start () {
        way = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        speed = Random.Range(5f, 20f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += way * speed*Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0f)
            Destroy(this.gameObject);
	}
}
