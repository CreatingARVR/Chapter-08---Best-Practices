bool CalculateCurvedPath(Vector3 position, Vector3 direction, //calcuates the teleportation path
                    Vector3 gravity, out Vector3 points) {
    int maxDistance = 500; //sets the max distance the path can travel
    Vector3 currPos = origin, hypoPos = origin, hypoVel = direction.normalized; //initialize variable to keep track off
    List<Vector3> v = new List<Vector3>(); //list of points
    RaycastHit hit; //gets raycast info at each step
    float curveCastLength = 0; //current distance traveled

    do { //loop
        v.Add(hypoPos); //add start
        currPos = hypoPos; //set start position as previous end postion
        hypoPos = currPos + hypoVel + (gravityDirection * Time.fixedDeltaTime); // calculate next point on curve
        hypoVel = hypoPos - currPos; //calulate the delta for the velocity
        curveCastLength += hypoVel.magnitude; // add velocity to distance 
    }
    while (Raycast(currPos, hypoVel, out hit, hypoVel.magnitude) == false //check physics to see if we hit the ground
                && curveCastLength < maxDistance);

    points = v; //return points
    return Raycast(currPos, hypoVel, out hit, hypoVel.magnitude); //check if landed
}

void RenderPath(List<Vector3> points) {
    path.pointCount = points.Count;
    for ( int i = 0; i < points.Count ; i++) {
        path.points[i] = points[i]; //set all points in Line Renderer
    }   
}
