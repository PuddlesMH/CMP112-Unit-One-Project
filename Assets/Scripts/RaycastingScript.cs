using UnityEngine;

public class RaycastingScript : MonoBehaviour
{
    public float rayDistance = 0.75f; //length of the ray, needs to be somewhere between 0.6 and 1.1 otherwise jumping gets a bit wonky
    public bool rayHit = false; //tracks if the player is touching the ground. used in the playercontroller script

    void Update()
    {
        RaycastAll();
    }

    void RaycastAll()
    {
        RaycastHit2D[] raycastInfo; //stores information on what the ray hits
        raycastInfo = Physics2D.RaycastAll(transform.position, -transform.up, rayDistance); //do the raycast and store the information

        if (raycastInfo.Length > 1) //check if the raycast hit anything (since it comes from the player it will always be at least one)
        {
            rayHit = true;
        }
        else
        {
            rayHit = false;
        }
    }
}
