using UnityEngine;
using System.Collections;

public class ActivateSound : MonoBehaviour {
    public AudioSource leftFoot;
    public AudioSource rightFoot;
	
    public void LeftFootStep()
    {
        leftFoot.Play();
    }
    public void RightFootStep()
    {
        rightFoot.Play();
    }
}
