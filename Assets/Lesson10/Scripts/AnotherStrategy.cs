using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SideMove", menuName = "ScriptableObjects/SideMove")]
public class AnotherStrategy : SimpleStrategy {

    public override void Move(Transform t)
    {
        //t.position = new Vector3(Mathf.Sin(Time.time*speed), 0f,0f);
        t.position = new Vector3(Mathf.Cos(Time.time * speed), Mathf.Sin(Time.time * speed), 0f);
    }
}
