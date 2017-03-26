using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour
{
    ShakeEffect filterScript;
    public float timer = -1f;
    public void Start()
    {
        //Получаем компонент с нашим эффектом.
        filterScript = this.GetComponent<ShakeEffect>();
    }
    //Метод для запуска счётчика
    public void SetTimer(float t)
    {
        timer = t;
    }
    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            // Если идёт обратный отсчёт, то делаем случайное смещение картинки
            filterScript.offsetX = Random.Range(-0.01f, 0.01f);
            // В своей игре я делал случайное приращение по Y, так что тут тоже так будет.
            filterScript.offsetY += Random.Range(-0.01f, 0.01f);
        }
        else {
            // Если отсчёт закончился делаем смещение нулевым
            filterScript.offsetX = filterScript.offsetY = 0f;
        }
    }
}