using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ShakeEffect : MonoBehaviour
{

    private Material material;
    public float offsetX, offsetY;
    void Awake()
    {
        //Создаём материал с нашим шейдером
        material = new Material(Shader.Find("Hidden/ShakeEffect")); 
    }

    //Метод вызываемый при рендере изображения.
    void OnRenderImage(RenderTexture source, RenderTexture destination)  
    {
     
        //Передаём наши смещения по X и Y в наш шейдер.
        material.SetFloat("_OffsetX", offsetX);
        material.SetFloat("_OffsetY", offsetY);
        //Применяем эффект.
        Graphics.Blit(source, destination, material);
    }
}