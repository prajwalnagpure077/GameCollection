using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Shape
{
    public Vector2[] blocks;
}

public class TetrisManager : MonoBehaviour
{
    [SerializeField] List<Shape> AllShapes = new List<Shape>();
    [SerializeField] GameObject Block,spawnPoint;

    List<GameObject> blocks = new List<GameObject>();
    GameObject currentShape;

    private void Start()
    {
        MoveShapeDown();
    }

    void SpawnNewShape()
    {
        Vector2[] shape = AllShapes[Random.Range(0, AllShapes.Count)].blocks;
        GameObject Container = new GameObject();
        Container.transform.position = spawnPoint.transform.position;
        foreach (var block in shape)
        {
            GameObject tempBlock = Instantiate(Block, Container.transform);
            tempBlock.transform.localPosition = block;
            blocks.Add(tempBlock);
        }
        currentShape = Container;
        MoveShapeDown();
    }

    void MoveShapeDown()
    {
        if (currentShape != null)
        {
            this.Delay(0.5f, () =>
            {
                foreach (var EachBlock in blocks)
                {
                    foreach (Transform EachShapeBlock in currentShape.transform)
                    {
                        if ((EachBlock.transform.position.y+1) == EachShapeBlock.position.y)
                        {
                            SpawnNewShape();
                        }
                        else
                        {
                            MoveShapeDown();
                        }
                    }
                }
                currentShape.transform.position += new Vector3(0, -1, 0);
            });
        }
        else
        {
            SpawnNewShape();
        }
    }
}
