using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreakoutManager : MonoBehaviour
{
    [SerializeField] GameObject PopUp;
    [SerializeField] UnityEngine.UI.Text message;

    public List<SpriteRenderer> m_list_blocks = new List<SpriteRenderer>();

    public static BreakoutManager instance;
    int score;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] float speed = 0.5f;
    [SerializeField] GameObject Slider,ball,BlocksPrefab;
    Vector2 lastPos;
    private void Awake()
    {
        instance = this;
        Slider = gameObject;
        Score.text = score.ToString();
        foreach (var item in m_list_blocks)
        {
            item.color = Color.HSVToRGB(Mathf.Clamp01(item.transform.position.y / 3),0.6f,1);
        }
    }

    public void SpawnNew()
    {
        GameObject go = Instantiate(BlocksPrefab);
        foreach (Transform child in go.transform)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            m_list_blocks.Add(sr);
            sr.color = Color.HSVToRGB(Mathf.Clamp01(sr.transform.position.y / 3), 0.6f, 1);
        }
    }

    public void AddScore(int toAdd)
    {
        score += toAdd;
        Score.text = score.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            float dist = Input.mousePosition.x - lastPos.x;
            Slider.transform.position += new Vector3(dist * speed, 0, 0);
            lastPos = Input.mousePosition;
        }
        if (Slider.transform.position.y-2 > ball.transform.position.y)
        {
            Time.timeScale = 0;                                                 
            PopUp.SetActive(true);
            message.text = $"Your Score {score}";
        }
    }
}