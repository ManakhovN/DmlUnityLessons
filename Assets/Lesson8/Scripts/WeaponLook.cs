using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLook : MonoBehaviour {
    Vector3 rotation;
    Camera main;
    void Start()
    {
        main = Camera.main;
        rotation = transform.rotation.eulerAngles;
    }

    void Update () {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);
            rotation.x = mousePos.x - transform.position.x;
            rotation.y = mousePos.y - transform.position.y;
            this.transform.right = rotation;
        }
	}
}
