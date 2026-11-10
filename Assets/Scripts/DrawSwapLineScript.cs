using UnityEngine;

public class DrawSwapLineScript : MonoBehaviour
{
    LineRenderer swapLine;
    float lineWidth = 0.04f;
    Vector3[] points;

    private void Awake() { //declare variables and set swapLine
        swapLine = GetComponent<LineRenderer>();
        swapLine.startWidth = lineWidth;
        swapLine.endWidth = lineWidth;
    }

    public void SetUpLine(Vector3[] _points) { //put start and end points into the points array
        swapLine.positionCount = _points.Length;
        points = _points;
    }

    private void Update() { //use points from the points array to draw the line
        for (int i = 0; i < points.Length; i++) { 
            swapLine.SetPosition(i, points[i]);
        }
    }
}
