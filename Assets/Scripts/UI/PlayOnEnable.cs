using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayOnEnable : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void OnEnable()
    {
        gameObject.GetComponent<Animator>().Play("0");
    }
}
