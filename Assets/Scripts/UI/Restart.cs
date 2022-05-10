using UnityEngine;

public class Restart : MonoBehaviour

{ 
    public void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
