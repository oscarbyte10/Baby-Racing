using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{

    //--------WAYPOINT--------
    public GameObject waypointContainer;
    public Transform[] waypoints = new Transform[2];
    private int currentWaypoint = 0;
    //--------CAR-----------
    Vector3 m_EulerAngleVelocity;
    public GameObject frontLeft;
    public GameObject frontRight;
    public float speed = 100;
    public float maxSteerAngle = 30;
    private bool hasWheelContact = false;
    private float motorForce = 0;
    private float steerAngle = 0;

    //--------MOVEMENT--------
    float deadZone = 0.1f;
    //
    public float groundedDrag = 3f;

    private float maxVelocity = 30;

    private float forwardAcceleration = 850f;
    private float reverseAcceleration = 150f;
    float thrust = 0f;

    public float tilt;

    private float turnStrength = 80f;
    public float turnValue = 0f;

    private float torque = 0f;
    //--------MOVEMENT--------

    //--------GAMEOBJECTS--------
    int layerMask;
    Rigidbody body;

    //public GameObject[] hoverPoints;

    public ParticleSystem[] dustTrails = new ParticleSystem[2];

    public Transform[] wheelTransform = new Transform[4]; //these are the transforms for our 4 wheels

    // the physical transforms for the car's wheels
    /*public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform rearLeftWheel;
    public Transform rearRightWheel;*/
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
        //GetWaypoints();

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


    }

    void FixedUpdate()
    {

        /*if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }*/

        

        Vector3 newPos = Vector3.MoveTowards(body.transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        body.MovePosition(newPos);
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        if()
        {
            m_EulerAngleVelocity = new Vector3(0, 100, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            body.MoveRotation(body.rotation * deltaRotation);
        }
        
        // Si suma una y al dividirlo entre la longitud del array el resto da 0 es que ha llegado al final del array y vuelve a empezar


        //--------MOVEMENT--------
        // Main Thrust
        //thrust = 0.0f;
        //float acceleration = Input.GetAxis("Vertical");

        //frontLeft.transform.localEulerAngles = new Vector3(0, steerAngle * maxSteerAngle, 0);
        //frontRight.transform.localEulerAngles = new Vector3(0, steerAngle * maxSteerAngle, 0);

        /*if (acceleration > deadZone)
            thrust = acceleration * forwardAcceleration;
        else if (acceleration < -deadZone)
            thrust = acceleration * reverseAcceleration;

        // Turning
        turnValue = 0.0f;
        float turnAxis = Input.GetAxis("Horizontal");
        if (Mathf.Abs(turnAxis) > deadZone)
            turnValue = turnAxis;
        //--------MOVEMENT--------

        //var emissionRate = 0;
        Suspension rueda; //referencia a la clase suspension
        rueda = gameObject.GetComponentInChildren<Suspension>(); //referencia  a la instancia particular/local de la clase suspension de cada rueda

        Debug.Log(rueda.grounded);

        if (rueda.grounded == true)
        {
            body.drag = groundedDrag;
            //emissionRate = 10;
        }
        else
        {
            body.drag = 0.1f;
            thrust /= 200f;
            turnValue /= 20f;
        }

        for (int i = 0; i < dustTrails.Length; i++)
        {
            //var emission = dustTrails[i].emission;
            //emission.rate = new ParticleSystem.MinMaxCurve(emissionRate);
        }
        //--------MOVEMENT--------


        //--------MOVEMENT--------

        // Handle Forward and Reverse forces
        //Debug.Log(Mathf.Abs(thrust));
        Debug.Log(transform.localPosition);

        if (thrust >= 0)
        {
            body.AddForce(transform.forward * thrust);
            torque = turnValue * turnStrength;

        }
        else
        {
            body.AddForce(transform.forward * thrust);
            torque = -turnValue * turnStrength;
        }

        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 forward = transform.forward;
            forward.y = 0;

            body.AddForce(forward * 100, ForceMode.Impulse); //aplicar impulso hacia delante local
        }

        Debug.Log(turnValue);

        // Handle Turn forces
        if (turnValue > 0)
        {
            Debug.Log(torque);
            Vector3 m_EulerAngleVelocity = new Vector3(0, torque, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            body.MoveRotation(body.rotation * deltaRotation);
        }
        else if (turnValue < 0)
        {
            Debug.Log(torque);
            Vector3 m_EulerAngleVelocity = new Vector3(0, torque, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            body.MoveRotation(body.rotation * deltaRotation);
        }

        // Limit max velocity
        if (body.velocity.sqrMagnitude > (body.velocity.normalized * maxVelocity).sqrMagnitude)
        {
            body.velocity = body.velocity.normalized * maxVelocity;
        }*/
        //--------MOVEMENT--------

    }
    // Funcion para que el IA vaya de un punto a otro
    /*void NavigateTowardsWaypoint()
    {

        //Obaservamos si se crea bien la RUTA
        //Debug.Log(currentWaypoint);

        Vector3 RelativeWaypointPosition = transform.InverseTransformPoint(new Vector3(
                                                                            waypoints[currentWaypoint].position.x,
                                                                            transform.position.y,
                                                                            waypoints[currentWaypoint].position.z));

        steerAngle = RelativeWaypointPosition.x / RelativeWaypointPosition.magnitude;

        // El coche frena en las curvas.
        if (steerAngle < 0.5f)
        {
            motorForce = RelativeWaypointPosition.z / RelativeWaypointPosition.magnitude - Mathf.Abs(steerAngle);
        }
        else
            motorForce = 0;

        if (RelativeWaypointPosition.magnitude < 20)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
                currentWaypoint = 0;
        }

    }*/
    
}
