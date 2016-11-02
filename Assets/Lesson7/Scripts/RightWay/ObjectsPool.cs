using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsPool : MonoBehaviour {
    public static ObjectsPool instance; // Синглтон
    public static ObjectsPool Instance
    {
        get {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ObjectsPool>();
            return instance;
        }
    }

    public Stack<RightSprite> pool = new Stack<RightSprite>(); //Стэк отработанных объектов
    public GameObject[] prefabs; 
    public void Put(RightSprite sprite) 
    {
        pool.Push(sprite);
        sprite.gameObject.SetActive(false);
    }

    public RightSprite Get()
    {
        if (pool.Count>0)
            return pool.Pop();
        else {
            GameObject temp = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            return temp.GetComponent<RightSprite>();
        }
    }
}
