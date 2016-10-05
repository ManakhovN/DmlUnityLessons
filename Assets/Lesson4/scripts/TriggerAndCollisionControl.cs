using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerAndCollisionControl : MonoBehaviour {
    public Text text;
    public ParticleSystem ps;
    public Rigidbody ball;
	void OnTriggerEnter(Collider col)
    {
        text.enabled = true;
        StartCoroutine(WaitForInput());
    }

    void OnTriggerExit(Collider col)
    {
        text.enabled = false;
        StopAllCoroutines();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "rod")
            ball.useGravity = true;
    }

    IEnumerator WaitForInput()
    {
        while (!Input.GetKey(KeyCode.Return))
            yield return new WaitForEndOfFrame();
        ps.Play();
        yield return null;
    }
}
