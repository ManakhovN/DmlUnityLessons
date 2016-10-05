using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Moving : MonoBehaviour {
    private Rigidbody _rBody;
    public Text warning;
    public Collider ball;
    public float speed = 1f;
	// Use this for initialization
	void Start () {
        _rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movingVector=transform.position;
        bool objectFound = false;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0f)
            movingVector += transform.right * horizontalInput*speed;
        if (verticalInput != 0f)
            movingVector += transform.forward * verticalInput*speed;
        transform.position=Vector3.MoveTowards(transform.position, movingVector, speed * Time.deltaTime);
        if (Physics.Raycast(transform.position, transform.forward, 3f))
        {
            warning.text = "Object in front of us";
            objectFound = true;
        }
        RaycastHit hitInfo;
        Ray newRay=new Ray(transform.position,transform.forward);
        if (ball.Raycast(newRay, out hitInfo, 5f))
        {
            warning.text = hitInfo.transform.name;
            objectFound = true;
        }
        if(!objectFound)
        {
            warning.text = string.Empty;
        }
	}
}
