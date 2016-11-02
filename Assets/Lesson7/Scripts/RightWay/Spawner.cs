using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    ObjectsPool pool;
    public float deltaTime = 2f;
    float timer = 2f;
    Vector3 zero = Vector3.zero;
    List<RightSprite> aliveSprites = new List<RightSprite>();
    void Start () {
        pool = ObjectsPool.Instance;
        timer = deltaTime;
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            RightSprite sprite = pool.Get();
            sprite.gameObject.SetActive(true);
            sprite.transform.position = zero;
            sprite.way = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            sprite.speed = Random.Range(5f, 20f);
            sprite.ResetLifeTime(5f);
            aliveSprites.Add(sprite);
            timer = deltaTime;
        }

        for (int i = aliveSprites.Count - 1; i >= 0; i--)
            if (aliveSprites[i].Move() < 0f)
            {
                pool.Put(aliveSprites[i]);
                aliveSprites.RemoveAt(i);
            }
    }
}
