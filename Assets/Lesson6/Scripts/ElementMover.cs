using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ElementMover : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.localPosition += (Vector3)eventData.delta;
    }
}
