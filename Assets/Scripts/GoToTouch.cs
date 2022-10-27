using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GoToTouch : MonoBehaviour {
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LineDrawer lineDrawer;

    private Vector3 previousWaypoint;
    public bool canMove = true;
    private List<Vector3> listOfWaypoints;

    private void Awake() {
        if(camera == null) {
            camera = Camera.main;
        }
        listOfWaypoints = new List<Vector3>();
        previousWaypoint = this.transform.position;
    }

    private void Update() {
        if(canMove == false) {
            return;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            Touch touch = Input.GetTouch(0);
            listOfWaypoints.Add(new Vector3 (camera.ScreenToWorldPoint(touch.position).x, camera.ScreenToWorldPoint(touch.position).y, 0));
        }
        if(listOfWaypoints.Count > 0) {
            lineDrawer.DrawListOfPoints(previousWaypoint, listOfWaypoints);
            this.transform.position = Vector3.MoveTowards(this.transform.position, listOfWaypoints[0], moveSpeed * Time.deltaTime);
            if (Vector3.Distance(this.transform.position, listOfWaypoints[0]) < 0.0001) {
                previousWaypoint = listOfWaypoints[0];
                listOfWaypoints.RemoveAt(0);
            }
        }
        else {
            lineDrawer.DrawLineBetweenTwoPoint(Vector3.zero, Vector3.zero);
        }
    }
}
