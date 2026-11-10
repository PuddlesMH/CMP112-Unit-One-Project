using UnityEngine;

public class SwapRaycastingScript : MonoBehaviour
{
    public RaycastHit2D Raycast2D(int _direction) { 
        RaycastHit2D raycastInfo; //stores information on what the ray hits
        raycastInfo = Physics2D.Raycast(transform.position, new Vector3(_direction, 0, 0), 20f); //do the raycast and store the information

        return raycastInfo;
    }
}
