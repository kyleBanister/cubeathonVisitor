using UnityEngine;

public class Jump : Command {
    private PlayerMovement playerMovement;
    public override void Execute() {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        playerMovement.Jump();
    }   
}