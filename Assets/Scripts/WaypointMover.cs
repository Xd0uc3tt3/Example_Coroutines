using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class WaypointMover : MonoBehaviour
{

    
    Rigidbody rb;

    List<Vector3> _waypoints = new List<Vector3>();

    [SerializeField]
    float _speed;

    // Add the position of all children tagged "Waypoint" to the _waypoints list
    // Also sets the position of the platform to the position of the 1st waypoint.
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        foreach(Transform childTransform in this.transform)
        {
            if (!childTransform.CompareTag("Waypoint")) continue;

            _waypoints.Add(childTransform.position);

        }

        if (_waypoints.Count == 0) return;


        transform.position = _waypoints[0];

        if (_waypoints.Count > 1)
        {
            //TODO: once MoveBetweenWayPoints method exists, uncomment the line below. 
            //StartCoroutine(MoveBetweenWayPoints());
        }
        
        

    }

    // COROUTINES: 
    // A coroutine is a nice way to run some code over time, allowing you to pause in the middle of a method and then resume later!
    // All coroutine methods must have a return type of IEnumerator. You run them by using StartCoroutine(MyCoroutineMethod())

    // Challenge: 
    // Create an IEnumerator MoveBetweenWayPoints below. 

    // The coroutine should make the platform move to the waypoints in order.
    // At each waypoint, wait for 1 second. Hint: WaitForSecondsRealTime(1f)
    
    // useful methods: Vector3.MoveTowards, rb.MovePosition
    
    // The solution should only be approximately 15-20 lines of code or less (not including bracket lines and whitespace). 


 
    
    private void OnDrawGizmos()
    {

        if (Application.isPlaying) return;

        List<Vector3> gizmoWaypoints = new List<Vector3>();

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Waypoint"))
                gizmoWaypoints.Add(child.position);
        }

        if (gizmoWaypoints.Count == 0) return;

        Gizmos.color = Color.green;

        for (int i = 0; i < gizmoWaypoints.Count; i++)
        {
            Gizmos.DrawSphere(gizmoWaypoints[i], 0.2f);

            if (i < gizmoWaypoints.Count - 1)
            {
                Gizmos.DrawLine(gizmoWaypoints[i], gizmoWaypoints[i + 1]);
            }
        }
    }




}
