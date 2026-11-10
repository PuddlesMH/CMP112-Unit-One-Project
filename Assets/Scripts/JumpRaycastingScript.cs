using UnityEngine;

public class JumpRaycastingScript : MonoBehaviour
{
    private float rayDistance = 0.75f; //length of the ray, needs to be somewhere between 0.6 and 1.1 otherwise jumping gets a bit wonky

    public bool RaycastAll() { 
        RaycastHit2D[] raycastInfo; //stores information on what the ray hits
        raycastInfo = Physics2D.RaycastAll(transform.position, -transform.up, rayDistance); //do the raycast and store the information

        if (raycastInfo.Length > 0) { //check if the raycast hit anything (since it comes from the player it will always be at least one)
            return true; //returns true if the ray hits something
        }
        else { 
            return false; //returns false if the ray doesnt hit something
        }
    }
}
