using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Shape
{
    public Vector2[] blocks;
}

[System.Serializable]
public struct table
{
    public List<List<Vector2>> chart;
}

public class TetrisManager : MonoBehaviour
{

    [SerializeField] List<Shape> AllShapes = new List<Shape>();
    [SerializeField] GameObject Block,spawnPoint,tableStart,tableEnd;
    [SerializeField] float speed = 0.5f;

    table Table = new table();
    [SerializeField] List<GameObject> blocks = new List<GameObject>();
    GameObject currentShape;

    private void Awake()
    {
        Table.chart = new List<List<Vector2>>();
        for (int _y = (int)tableStart.transform.position.y; _y <= (int)tableEnd.transform.position.y; _y++)
        {
            List<Vector2> cells = new List<Vector2>();
            for (int _x = (int)tableStart.transform.position.x; _x <= (int)tableEnd.transform.position.x; _x++)
            {
                cells.Add(new Vector2(_x, _y));
            }
            Table.chart.Add(cells);
        }
        List<Vector2> _cell = new List<Vector2>();
        for (int _x = (int)tableStart.transform.position.x; _x <= (int)tableEnd.transform.position.x; _x++)
        {
            _cell.Add(new Vector2(_x, (int)tableEnd.transform.position.y-1));
            Instantiate(Block, new Vector2(_x, (int)tableStart.transform.position.y - 1), Quaternion.identity);
        }
        Table.chart.Add(_cell);
    }

    private void Start()
    {
        MoveShapeDown();
    }
    Vector2 mousePos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            int NextPos = (int)(Input.mousePosition.x - mousePos.x);
            if (Mathf.Abs(NextPos) > 30)
            {
                if (currentShape != null)
                {
                    currentShape.transform.position += new Vector3(Mathf.Clamp(NextPos, -1, 1), 0f,0);
                    mousePos = Input.mousePosition;
                }
            }
            NextPos = (int)(Input.mousePosition.y - mousePos.y);
            if (Mathf.Abs(NextPos) > 50)
            {
                Debug.Log(NextPos);
                currentShape.transform.Rotate(new Vector3(0,0, Mathf.Clamp(NextPos, -1, 1) * 90));
                mousePos = Input.mousePosition;
            }
        }
    }

    void SpawnNewShape()
    {
        checkForPoints();
        if (currentShape != null)
        {
            foreach (Transform Child in currentShape.transform)
            {
                blocks.Add(Child.gameObject);
            }
        }
        Vector2[] shape = AllShapes[Random.Range(0, AllShapes.Count)].blocks;
        GameObject Container = new GameObject();
        Container.transform.position = spawnPoint.transform.position;
        foreach (var block in shape)
        {
            GameObject tempBlock = Instantiate(Block, Container.transform);
            tempBlock.transform.localPosition = block;
        }
        currentShape = Container;
        MoveShapeDown();
    }

    void MoveShapeDown()
    {
        if (currentShape != null)
        {
            this.Delay(speed, () =>
            {
                foreach (var EachBlock in blocks)
                {
                    foreach (Transform EachShapeBlock in currentShape.transform)
                    {
                        if ((EachBlock.transform.position.y+1) == EachShapeBlock.position.y)
                        {
                            SpawnNewShape();
                            return;
                        }
                    }
                }
                currentShape.transform.position += new Vector3(0, -1, 0);
                MoveShapeDown();
            });
        }
        else
        {
            SpawnNewShape();
        }
    }
    void checkForPoints()
    {
        if (blocks.Count > 0)
        {
            foreach (GameObject block in blocks)
            {

            }
        }
    }
}
