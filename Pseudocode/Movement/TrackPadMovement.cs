public Rigidbody rigidbody; // set from the Unity Interface
public float speed; // set from the Unity Interface

void LinearMovement() {
    Vector2 trackpad = null;
    if (Input.GetTouch( LeftTrackPad )) { //check if left trackpad is touched
        trackpad = Input.GetLeftPad(); //set left trackpad 2D position
    }
    else if (Input.GetTouch( RightTrackPad )) { //check if right trackpad is touched
        trackpad = Input.GetRightPad(); //set right trackpad 2D position
    }

    if (trackpad != null) {
        rigidbody.velocity = 
            new Vector3(trackpad.x, 0, trackpad.y) * speed; //set XZ velocity, so we don’t start flying
    }
    else {
        rigidbody.velocity = Vector3.zero; //when not pressed, set to 0;
    }
}