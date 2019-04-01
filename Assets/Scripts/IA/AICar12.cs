using UnityEngine;
using System.Collections;

public class AICar12 : MonoBehaviour {
	
	public Vector3 centerOfMass = Vector3.zero;
	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;
	
	public float speed = 100;
	public float maxSteerAngle = 30;
	
	private bool hasWheelContact = false;
	private float motorForce = 0;
	private float steerAngle = 0;
	
	public GameObject waypointContainer;
	private Transform[] waypoints;
	private int currentWaypoint = 1;
	
	public void HasContact(){
		hasWheelContact = true;
	}
	
	// Use this for initialization
	void Start () {
		GetWaypoints();
		this.GetComponent<Rigidbody>().centerOfMass = centerOfMass;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		NavigateTowardsWaypoint();
		
		if(hasWheelContact){
			frontLeftWheel.motorTorque = motorForce * speed;
			frontRightWheel.motorTorque = motorForce * speed;
		}
			
		frontLeftWheel.transform.localEulerAngles = new Vector3(0, steerAngle * maxSteerAngle, 0);
		frontRightWheel.transform.localEulerAngles = new Vector3(0, steerAngle * maxSteerAngle, 0);
		hasWheelContact = false;
	}
	
	void GetWaypoints(){
		Transform[] potencialWaypoints = waypointContainer.GetComponentsInChildren<Transform>();
		waypoints = new Transform[potencialWaypoints.Length-1];
		
		int i = 0;
		foreach(Transform potencialWaypoint in potencialWaypoints)
			if(potencialWaypoint != waypointContainer.transform)
				waypoints[i++] = potencialWaypoint;
	}
	
	void NavigateTowardsWaypoint(){
		Vector3 RelativeWaypointPosition = transform.InverseTransformPoint(new Vector3(
																			waypoints[currentWaypoint].position.x,
																			transform.position.y,
																			waypoints[currentWaypoint].position.z));
		
		steerAngle = RelativeWaypointPosition.x / RelativeWaypointPosition.magnitude;
		
		/*float targetAngle = Mathf.Antan2(RelativeWaypointPosition.x, RelativeWaypointPosition.z);
		targetAngle *= Mathf.Rad2Deg;*/
		
		// Elk coche frena en las curvas.
		if(steerAngle < 0.5f){
			motorForce = RelativeWaypointPosition.z / RelativeWaypointPosition.magnitude - Mathf.Abs(steerAngle);
		}
		else
			motorForce = 0;
		
		if(RelativeWaypointPosition.magnitude < 20) {
			currentWaypoint++;
			if(currentWaypoint >= waypoints.Length)
				currentWaypoint = 0;
		}
	}
}
