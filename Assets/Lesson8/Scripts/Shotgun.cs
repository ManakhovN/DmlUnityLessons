using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {
    public ObjectPool bulletsPool;
    Camera main;
    List<Bullet> bullets = new List<Bullet>();
    public float damage = 10f;
    public int maxBulletsCount = 6;
    public float angleDelta = 5f;
    Transform bulletsParent;
    [HideInInspector]
    public int currentBulletsCount = 6;

    public delegate void BulletNumChangeEventHandler(Shotgun sender);

    public event BulletNumChangeEventHandler BulletNumChanged;

    public void Start()
    {
        main = Camera.main;
        bulletsParent = GameObject.Find("BulletsParent").transform;
    }

	void Update () {
        Shoot();
        RefreshAllBullets();
    }


    public void RefreshAllBullets()
    {
         for (int i = bullets.Count-1; i >= 0; i--)
                {
                    bullets[i].Refresh();
                    Vector3 pos = bullets[i].transform.position;
                    KillableObject hitted = bullets[i].hitted;
                    if ((pos - transform.position).sqrMagnitude > 625)
                    {
                        RemoveBullet(bullets[i]);              
                    }
                    if (hitted != null)
                    {
                        RemoveBullet(bullets[i]);
                        hitted.TakeDamage(damage);
                    }
                }
    }

    void RemoveBullet(Bullet bullet)
    {
        bullets.Remove(bullet);
        bulletsPool.PutObject(bullet.gameObject, 0);
    }

    void Shoot()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        currentBulletsCount--;
        SpawnBullets();
    }

    private void SpawnBullets()
    {
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);
        float angle = CalculateVectorsAngle(mousePos, transform.position);
        for (int i = 0; i < maxBulletsCount; i++)
        {
            GameObject go = bulletsPool.GetObject(0);
            go.transform.position = this.transform.position;
            go.transform.rotation = Quaternion.Euler(0, 0, angle + UnityEngine.Random.Range(-angleDelta, angleDelta));
            go.transform.SetParent(bulletsParent);
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.hitted = null;
            bullets.Add(bullet);
        }
    }

    float CalculateVectorsAngle(Vector3 v1, Vector3 v2)
    {
        float dx = v1.x - v2.x;
        float dy = v1.y - v2.y;
        float dist = Mathf.Sqrt(dx * dx + dy * dy);
        float angle;
        if (dx < 0)
            angle = 180 - Mathf.Asin(dy / dist) * Mathf.Rad2Deg;
        else
            angle = Mathf.Asin(dy / dist) * Mathf.Rad2Deg;
        return angle;
    }
}
