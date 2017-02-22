using UnityEngine;
[ExecuteInEditMode]
public class LookAtPoint : MonoBehaviour
{
	public Vector3 lookAtPoint = Vector3.zero;
	public string password;
	public Color c;
	void Update()
	{
		transform.LookAt (lookAtPoint);
	}
}