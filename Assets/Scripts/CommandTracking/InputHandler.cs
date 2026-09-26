using UnityEngine;

public class InputHandler : MonoBehaviour {
    private Invoker _invoker;
    private bool _isReplaying = false;
    private bool _isRecording = true;
    private PlayerMovement playerMovement;
    private Command _buttonA, _buttonD, _buttonSpace;

    public void StartReplay() {
        _isReplaying = true;
        _invoker.Replay();
    }

    void Start() {
        _invoker = Invoker.Instance;
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        GameObject objA = new GameObject();
        objA.name = "buttonA";
        _buttonA = objA.AddComponent<MoveLeft>();
        GameObject objB = new GameObject();
        objB.name = "buttonD";
        _buttonD = objB.AddComponent<MoveRight>();
        GameObject objSpace = new GameObject();
        objSpace.name = "buttonSpace";
        _buttonSpace = objB.AddComponent<Jump>();

        if (GameManager.IsReplay) {
            StartReplay();
        } else {
            _invoker.Restart();
            _invoker.Record();
        }
    }
    void FixedUpdate() {
        if (!_isReplaying && _isRecording) {
            if (Input.GetKey(KeyCode.A)) {
                _invoker.ExecuteCommand(_buttonA);
            }
            if (Input.GetKey(KeyCode.D)) {
                _invoker.ExecuteCommand(_buttonD);
            }
            if (Input.GetKey(KeyCode.Space)) {
                _invoker.ExecuteCommand(_buttonSpace);
            }
        }
    }
}