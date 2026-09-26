using UnityEngine;

public class MoveRight : Command {
    private PlayerMovement playerMovement;
    public override void Execute() {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        playerMovement.MoveRight();
    }   
}
