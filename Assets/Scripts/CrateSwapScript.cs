using UnityEngine;

public class CrateSwapScript : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Vector3 CrateSwapPosition(Vector3 _newPosition)
    {
        Vector3 currentPosition = (transform.position);
        transform.position = _newPosition;
        return currentPosition;
    }
}
