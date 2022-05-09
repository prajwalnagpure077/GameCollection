using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheMainMenu : MonoBehaviour
{
    public void LoadAScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
