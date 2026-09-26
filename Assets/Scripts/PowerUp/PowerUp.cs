using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUp: ScriptableObject, VisitorInterface {
    public string PowerUpName;
    public GameObject PowerUpPrefab;
    public string powerupDescription;

    public void Visit(Jumper jumper) {
        jumper.hasJetpack = true;
    }
}
