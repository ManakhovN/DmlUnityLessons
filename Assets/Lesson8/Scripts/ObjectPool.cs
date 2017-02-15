using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    List<Stack<GameObject>> deadObjects= new List<Stack<GameObject>>();
    public GameObject[] prefabs;
    private void Start()
    {
        for (int i = 0; i < prefabs.Length; i++)
            deadObjects.Add(new Stack<GameObject>());
    }

    public void PutObject(GameObject go, int id) {
        deadObjects[id].Push(go);
        go.SetActive(false);
    }

    public GameObject GetObject(int id)
    {
        GameObject go = null;
        if (deadObjects[id].Count>0)
            go = deadObjects[id].Pop();
        else 
            go = Instantiate(prefabs[id]);
        go.SetActive(true);
        return go;
    }

    public int GetPrefabsCount()
    {
        return prefabs.Length;
    }
}
