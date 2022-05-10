using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBall : MonoBehaviour
{
    [SerializeField] GameObject lowerLimit;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.Delay(2f, () =>
        {
            rb.AddForce(new Vector2(Random.Range(-9, 9), Random.Range(-5, -8)), ForceMode2D.Impulse);
        });
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(Random.Range(-9,9),Random.Range(6,12)),ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("BreakoutBlock"))
        {
            BreakoutManager.instance.m_list_blocks.Remove(collision.gameObject.GetComponent<SpriteRenderer>());
            Destroy(collision.gameObject);
            BreakoutManager.instance.AddScore(10);
            
        }
    }
    private void Update()
    {
        if (BreakoutManager.instance.m_list_blocks.Count <= 0 && lowerLimit.transform.position.y > gameObject.transform.position.y)
        {
            BreakoutManager.instance.SpawnNew();
        }
    }
}
