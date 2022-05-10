using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceManager : MonoBehaviour
{
    public static SpaceManager instance;

    [SerializeField] UnityEngine.UI.Text message;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] float spacing = 1, moveDelay = 1, CloseDelay = 10;
    [SerializeField] GameObject[] EnemiesPrefab;
    [SerializeField] GameObject startPos,endPos,PopUp;
    public GameObject EnemyProjectile;
    [HideInInspector] public List<GameObject> enemies = new List<GameObject>();

    GameObject currentScene;
    double moveTime = 64,closeTime = 64;
    bool leftDirection = false;
    int score;

    private void Awake()
    {
        instance = this;
    }
    public int GetPoint(int type)
    => type switch
    {
        0 => 10,
        1 => 20,
        2 => 30,
        3 => 100,
    };

    void spawnInScene()
    {
        if (Time.timeScale > 0)
        {
            currentScene = new GameObject();
            for (int x = (int)startPos.transform.position.x; x <= (int)endPos.transform.position.x; x++)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject tempEnemy = Instantiate(EnemiesPrefab[i], new Vector2(x, (startPos.transform.position.y + i) * spacing), Quaternion.identity, currentScene.transform);
                    tempEnemy.AddComponent<SpaceEnemyDetails>();
                    tempEnemy.GetComponent<SpaceEnemyDetails>().Points = GetPoint(i);
                    enemies.Add(tempEnemy);
                }
            }
            moveTime = Time.time + moveDelay;
            closeTime = Time.time + CloseDelay;
            CloseDelay -= 1;
            moveDelay -= 0.1f;
            ShootPlayer();
        }
    }
    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (closeTime < Time.time)
            {
                closeTime = Time.time + CloseDelay;
                moveTime = Time.time + moveDelay;
                MoveCloser();
            }
            else if (moveTime < Time.time)
        {
            moveTime = Time.time+ moveDelay;
            if (leftDirection)
            {
                if (CheckLeft())
                {
                    MoveLeft();
                }
                else if (CheckRight())
                {
                    MoveRight();
                }
            }
            else
            {
                if (CheckRight())
                {
                    MoveRight();
                }
                else if (CheckLeft())
                {
                    MoveLeft();
                }
            }
        }
            if (currentScene == null || currentScene.transform.childCount < 1)
        {
            spawnInScene();
        }
        }
    }
    private void ShootPlayer()
    {
        this.Delay(Random.Range(4,7) * moveDelay, () =>
        {
            if (Time.timeScale > 0)
            {
                enemies[Random.Range(0, enemies.Count)].GetComponent<SpaceEnemyDetails>().ShootProjectile();
                ShootPlayer();
            }
        });
    }
    void MoveCloser()
    {
        if (Time.timeScale > 0)
        {
            currentScene.transform.position -= new Vector3(0, 1, 0);
            if (CheckButtom())
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        PopUp.SetActive(true);
        message.text = $"Score : {score}";
    }

    void MoveLeft()
    {
        leftDirection = true;
        currentScene.transform.position -= new Vector3(1, 0, 0);
    }
    void MoveRight()
    {
        leftDirection = false;
        currentScene.transform.position += new Vector3(1, 0, 0);
    }
    bool CheckLeft()
    {
        float tempX = startPos.transform.position.x;
        foreach (var item in enemies)
        {
            if (item.transform.position.x < tempX)
            {
                return false;
            }
        }
        return true;
    }
    bool CheckButtom()
    {
        float tempY = SpacePlayer.instance.transform.position.y;
        foreach (var item in enemies)
        {
            if (item.transform.position.y <= tempY)
            {
                return true;
            }
        }
        return false;
    }
    public void addScore(int toadd)
    {
        score += toadd;
        Score.text = score.ToString();
    }
    bool CheckRight()
    {
        float tempX = endPos.transform.position.x;
        foreach (var item in enemies)
        {
            if (item.transform.position.x > tempX)
            {
                return false;
            }
        }
        return true;
    }
}
