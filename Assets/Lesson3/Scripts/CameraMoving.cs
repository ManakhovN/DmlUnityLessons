using UnityEngine;
using System.Collections;

public class CameraMoving : MonoBehaviour {
    Vector3 movingPosition;
    public Transform target;
    public float speed;
	void Start () {
        movingPosition.z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        movingPosition.x = target.position.x;
        movingPosition.y = target.position.y; 
        transform.position = Vector3.Lerp(transform.position, movingPosition, Time.deltaTime * speed);
	}
}
