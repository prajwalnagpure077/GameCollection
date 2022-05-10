using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnHide : MonoBehaviour
{
    public void Hide(GameObject GO)
    {
        GO.SetActive(false);
    }
    public void Show(GameObject GO)
    {
        GO.SetActive(true);
    }
}
