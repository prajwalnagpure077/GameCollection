using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PongManager : MonoBehaviour
{
    [SerializeField,Range(0,5)]
    float enemySpeed;
    [SerializeField, Range(0f, 0.2f)]
    float Speed;
    [SerializeField]
    GameObject BallPrefab, enemy, player, LeftBoundry, RightBoundry;
    [SerializeField]
    TextMeshProUGUI Score, Timings;
    GameObject ball;
    Vector2 mousePos;
    double time = 0;

    int EnemyScore, PlayerScore;

    private void Start()
    {
        NewBall();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 mouseCurrentPos = Input.mousePosition;
            float dist = mouseCurrentPos.y - mousePos.y;
            mousePos = mouseCurrentPos;
            player.transform.position += new Vector3(0, dist * Speed);
        }
        if (ball.transform.position.x < LeftBoundry.transform.position.x)
        {
            Debug.Log("Player Point");
            PlayerScore += 1;
            NewBall();
        }
        else if (ball.transform.position.x > RightBoundry.transform.position.x)
        {
            Debug.Log("Enemy Point");
            EnemyScore += 1;
            NewBall();
        }
        if (ball.transform.position.y > LeftBoundry.transform.position.y||ball.transform.position.y<RightBoundry.transform.position.y)
        {
            NewBall();
        }

        if (ball != null)
        {
            Vector3 target = enemy.transform.position;
            target.y = ball.transform.position.y;
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, target, Time.deltaTime * enemySpeed);
        }
        time += Time.deltaTime;
        var _time = TimeSpan.FromSeconds(time);
        Timings.text = string.Format("{0:D2}:{1:D2}", _time.Minutes, _time.Seconds, _time.Milliseconds.ToString().Substring(0, 1));
    }
    void NewBall()
    {
        if (ball != null)
        {
            Destroy(ball);
        }
        Score.text = $"{EnemyScore} : {PlayerScore}";
        ball = Instantiate(BallPrefab, Vector3.zero, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2((UnityEngine.Random.value > 0.5f) ? 1 : -1, Mathf.Clamp(UnityEngine.Random.Range(-0.7f, 0.7f),0.2f,1f)) * 6, ForceMode2D.Impulse);
        if (EnemyScore >= 10)
        {
            //Prajwal Lost
        }
        else if (PlayerScore >= 10)
        {
            //Prajwal Won
        }
    }
}
