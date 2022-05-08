using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public static class Extras
{
    public static void Delay(this MonoBehaviour mono,float t, Action a)
    {
        mono.StartCoroutine(delayAndExc(t, a));
    }
    public static IEnumerator delayAndExc(float t, Action a)
    {
        yield return new WaitForSeconds(t);
        a?.Invoke();
    }
}