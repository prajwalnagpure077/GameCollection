using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void pause()
    {
        Time.timeScale = 0;
    }
}
