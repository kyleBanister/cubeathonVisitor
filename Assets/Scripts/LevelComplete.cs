using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewLevel : MonoBehaviour {
    public void LoadNextLevel() {
        Debug.Log("Loading Scene!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
