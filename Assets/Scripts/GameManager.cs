using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public float RestartDelay = 1f;
    bool GameHasEnded = false;
    bool ContinueStaller = false;
    public static bool IsReplay = false;

    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindAnyObjectByType<GameManager>();
                if (_instance == null) {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManager).Name;
                    _instance = obj.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    void Awake() {
        if (_instance == null) {
            _instance = this as GameManager;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
        
    }

    public void CompleteLevel() {
        if (!IsReplay || ContinueStaller) {
            IsReplay = true;
            Invoke("Restart", RestartDelay);
            ContinueStaller = true;
        } else {
            IsReplay = false;
            GameObject LevelComplete = FindAnyObjectByType<Canvas>().GetComponentInChildren<LoadNewLevel>(true).gameObject;
            LevelComplete.SetActive(true);
        }
    }
    
    public void EndGame() {
        if (!GameHasEnded) {
            GameHasEnded = true;
            Debug.Log("GAME OVER!");
            Invoke("Restart", RestartDelay);
        }
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameHasEnded = false;
        ContinueStaller = false;
    }
}
