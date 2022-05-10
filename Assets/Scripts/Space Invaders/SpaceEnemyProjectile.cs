using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyProjectile : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            transform.position += new Vector3(0, -(speed * Time.deltaTime), 0);
            if (transform.position.y < SpacePlayer.instance.transform.position.y - 2)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.timeScale > 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SpaceManager.instance.GameOver();
            }
            if (collision.gameObject.CompareTag("SpaceProjectile"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
