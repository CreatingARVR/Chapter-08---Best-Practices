public Collider capsule; // set from the Unity Interface
public Transform player; // set from the Unity Interface

void AdjustCapsuleHeight() {
    var playerHeightOffset = player.localPosition; //player's height from ground
    capsule.height = playerHeightOffset; //set the height
    capsule.localPosition.y = -playerHeightOffset / 2; //because capsule pivot is in the center
}