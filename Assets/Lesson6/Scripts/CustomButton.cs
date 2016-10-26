using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
    Image img;
    public Sprite EnterSprite;
    public Sprite StandartSprite;
    public Sprite PressSprite;
    public UnityEvent e;
    bool isInside = false;
	void Start () {
        img = this.GetComponent<Image>();
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = EnterSprite;
        isInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = StandartSprite;
        isInside = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = PressSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        e.Invoke();
        if (isInside)
            img.sprite = EnterSprite;
        else
            img.sprite = StandartSprite;
    }


}
