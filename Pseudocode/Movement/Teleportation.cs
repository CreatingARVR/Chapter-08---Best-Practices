public Vector3 gravity; //set in inspector as (0, -9.8, 0)
public LineRenderer path; //the component that will render our path

private Vector3 teleportLocation; //save the location of where we want to teleport
private Player player; //the player we will be teleporting

void Update() { //called every fame
    if (!CheckTeleport(LeftHand)) { //check the left hand
        CheckTeleport(RightHand); //if not teleporting with left hand try right hand
    }
}

bool CheckTeleport(Hand hand) { //check a hand to see the status of teleporting
    List<Vector3> curvedPoints; //the points on the teleport curve

    if (hand.GetPressed(TrackPad)) { //check if track pad ( button for teleport) is pressed
        if (CalcuateCurvedPath(hand.position, hand.forward, gravity
                          , out curvedPoints)) { //calculate teleport
            RenderPath(curvedPoints); //if calculate, render the path
            teleportLocation = curvedPoints[curvedPoints.Count - 1]; //set teleport point
            return true;
        }
    } else if (hand.GetPressedUp(TrackPad)) { //time to actually teleport
        player.position = teleportLocation; //move the player instantly
    }

    return false; //we are not using this hand currently for teleporting
}
