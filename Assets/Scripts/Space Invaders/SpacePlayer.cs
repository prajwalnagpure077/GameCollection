using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour
{
    public static SpacePlayer instance;
    [SerializeField] GameObject BulletPrefab;



    bool canShoot = true;
    float speed = 0.01f, lastTouchTime = -100;
    Vector2 lastPos,startPos;
    GameObject CurrentBullet;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastPos = Input.mousePosition;
                startPos = lastPos;
                lastTouchTime = Time.time;
            }
            if (Input.GetMouseButton(0))
            {
                float dist = Input.mousePosition.x - lastPos.x;
                transform.position += new Vector3(dist * speed, 0, 0);
                lastPos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - lastTouchTime < 0.3f && Vector2.Distance(startPos, Input.mousePosition) < 3f)
                {
                    Shoot();
                }
            }
            if (CurrentBullet == null)
            {
                canShoot = true;
            }
        }
    }

    void Shoot()
    {
        if (Time.timeScale > 0)
        {
            if (canShoot)
            {
                canShoot = false;
                CurrentBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
