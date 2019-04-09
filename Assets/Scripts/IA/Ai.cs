using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{

    //--------WAYPOINT--------
    public GameObject waypointContainer;
    private Transform[] waypoints;
    private int currentWaypoint = 0;
    private bool contact = false;
    //--------CAR-----------
    Vector3 m_EulerAngleVelocity;
    public GameObject frontLeft;
    public GameObject frontRight;
    public float speed = 100;
    public float maxSteerAngle = 30;
    private bool hasWheelContact = false;
    private float motorForce = 0;
    private float steerAngle = 0;
    //--------GAMEOBJECTS--------
    int layerMask;
    Rigidbody body;

    public ParticleSystem[] dustTrails = new ParticleSystem[2];

    public Transform[] wheelTransform = new Transform[4]; //these are the transforms for our 4 wheels

    //--------GAMEOBJECTS--------

    // -- Crear el array de los waypoints a partir de los hijos del objeto WayPoints
    void GetWaypoints()
    {
        Transform[] potencialWaypoints = waypointContainer.GetComponentsInChildren<Transform>();
        waypoints = new Transform[potencialWaypoints.Length - 1];
        // Quita el padre de los waypoint
        int i = 0;
        foreach (Transform potencialWaypoint in potencialWaypoints)
            if (potencialWaypoint != waypointContainer.transform)
                waypoints[i++] = potencialWaypoint;
        Debug.Log("Waypoints creados: "+i);
        //Debug.Log(waypoints[i]);
    }

    void Start()
    {
        // -- Creamos array de waypoints
        GetWaypoints();

        //coche = GetComponent<Rigidbody>();

        //--------GAMEOBJECTS--------
        body = GetComponent<Rigidbody>();
        body.centerOfMass = Vector3.down; //UNO POR DEBAJO DEL VEHICULO, no es realista, pero asi sera dificil que el coche quede boca abajo

        layerMask = 1 << LayerMask.NameToLayer("Vehicle");
        layerMask = ~layerMask;

        //--------GAMEOBJECTS--------

    }

    void Update()
    {
        Vector3 newPos = Vector3.MoveTowards(body.transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        body.MovePosition(newPos);
        float angles;
        angles = newPos.x / newPos.magnitude;
        //transform.rotation = Quaternion.Euler(angles);
        Vector3 relativePos = (waypoints[currentWaypoint].position + new Vector3(0, 1.5f, 0)) - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos);
        
        if (contact)
        {
            //body.AddTorque(relativePos * Time.deltaTime);
            body.MoveRotation(rotation);
            //Cuando llega al máximo de waypoints vuelve a empezar
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            contact = false;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Waypoint"))
        {
            contact = true;
        }
    }
    
}
