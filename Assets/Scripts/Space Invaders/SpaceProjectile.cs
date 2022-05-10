using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        if (Time.timeScale > 0)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            if (transform.position.y > 13)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.timeScale > 0)
        {
            if (collision.gameObject.CompareTag("SpaceEnemy"))
            {
                SpaceManager.instance.enemies.Remove(collision.gameObject);
                SpaceManager.instance.addScore(collision.gameObject.GetComponent<SpaceEnemyDetails>().Points);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("SpaceProjectile"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
