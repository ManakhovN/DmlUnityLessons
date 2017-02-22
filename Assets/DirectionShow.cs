using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DirectionShow : MonoBehaviour {


	void Update () {
		Debug.DrawRay (transform.position, transform.forward, Color.magenta, 3f);
	}
}
