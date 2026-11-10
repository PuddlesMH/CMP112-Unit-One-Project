using UnityEngine;

public class CrateSwapScript : MonoBehaviour
{
    Rigidbody rb;

    private void Start() {  //add rigidbody component to rb
        rb = GetComponent<Rigidbody>();
    }

    public Vector3 CrateSwapPosition(Vector3 _newPosition) {
        Vector3 currentPosition = (transform.position); //set "currentPosition" vector = to crate position
        transform.position = _newPosition; //move crate to _newPosition
        return currentPosition; //output currentPosition variable
    }
}
