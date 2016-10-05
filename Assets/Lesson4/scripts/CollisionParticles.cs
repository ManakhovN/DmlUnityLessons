using UnityEngine;
using System.Collections;

public class CollisionParticles : MonoBehaviour {

	void OnParticleCollision(GameObject go)
    {
        Rigidbody _goRigid = go.GetComponent<Rigidbody>();
        if(_goRigid!=null && _goRigid.useGravity==false)
        {
            _goRigid.AddForce(transform.forward*0.1f);
        }
    }
}
