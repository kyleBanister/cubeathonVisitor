using UnityEngine;

public class MoveLeft : Command {
    private PlayerMovement playerMovement;
    public override void Execute() {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        playerMovement.MoveLeft();
    }   
}