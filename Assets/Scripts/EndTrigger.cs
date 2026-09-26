using UnityEngine;

public class EndTrigger : MonoBehaviour {
    private void OnTriggerEnter() {
        FindAnyObjectByType<GameManager>().CompleteLevel();
    }
}
