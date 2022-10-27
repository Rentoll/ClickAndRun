using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {
    [SerializeField]
    private LineRenderer lineRenderer;

    public void DrawListOfPoints(List<Vector3> listOfWaypoints) {
        lineRenderer.positionCount = listOfWaypoints.Count;
        lineRenderer.SetPositions(listOfWaypoints.ToArray());
    }

    public void DrawListOfPoints(Vector3 beggining, List<Vector3> listOfWaypoints) {
        lineRenderer.positionCount = listOfWaypoints.Count + 1;
        lineRenderer.SetPosition(0, beggining);
        for(int i = 0; i < listOfWaypoints.Count; i++) {
            lineRenderer.SetPosition(i + 1, listOfWaypoints[i]);
        }
    }

    public void DrawLineBetweenTwoPoint(Vector3 beggining, Vector3 ending) {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, beggining);
        lineRenderer.SetPosition(1, ending);
    }

}
