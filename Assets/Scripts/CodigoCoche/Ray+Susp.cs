using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCoche : MonoBehaviour
{

    /*
    public float aceleracion = 20f;
    public float velocidadMax = 100f;
    public Rigidbody coche;
    */

    //--------RAYCAST--------
    //public float hoverForce = 1000;
    //public float gravityForce = 500f;
    public float hoverHeight = 1.5f;
    //--------RAYCAST--------

    //--------MOVEMENT--------
    float deadZone = 0.1f;

    public float groundedDrag = 3f;

    public float maxVelocity = 10;

    public float forwardAcceleration = 200f;
    public float reverseAcceleration = 50f;
    float thrust = 0f;

    public float turnStrength = 10f;
    float turnValue = 0f;
    //--------MOVEMENT--------

    //--------GAMEOBJECTS--------
    int layerMask;
    Rigidbody body;

    //public GameObject[] hoverPoints;

    public ParticleSystem[] dustTrails = new ParticleSystem[2];

    public Transform[] wheelTransform = new Transform[4]; //these are the transforms for our 4 wheels

    // the physical transforms for the car's wheels
    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform rearLeftWheel;
    public Transform rearRightWheel;
    //--------GAMEOBJECTS--------

    public float hoverForce = 1000;
    public Transform hoverPoint1;
    public GameObject hoverPoint2;

    public bool grounded;
    public float gravityForce = 500f;


    void Start()
    {
        //coche = GetComponent<Rigidbody>();

        //--------GAMEOBJECTS--------
        body = GetComponent<Rigidbody>();
        body.centerOfMass = Vector3.down; //UNO POR DEBAJO DEL VEHICULO

        layerMask = 1 << LayerMask.NameToLayer("Vehicle");
        layerMask = ~layerMask;

         Transform hoverPoint1;

        Vector3 vec = new Vector3(0.5f, 0f, 0f);

        //--------GAMEOBJECTS--------

    }

    void Update()
    {


    }

    void FixedUpdate()
    {
        /*
 
        //Vector3 fuerza = new Vector3(0.0f, 1.0f, 0.0f); //aplicar fuerza hacia arriba.
        Vector3 fuerza = new Vector3(0.0f, 0.0f, 1.0f); //aplicar fuerza hacia delante.

        var velVector = coche.velocity; //recoge la velocidad del rigidbody en forma de vector
        float velActual = velVector.magnitude; //recoge la longitud del vector velocidad (el modulo)

        Debug.Log(velVector);

        //Debug.Log(velActual);

        if (Input.GetKey(KeyCode.W))
        {
            if (velActual < velocidadMax)
            {
                coche.AddForce(fuerza * aceleracion, ForceMode.Impulse);
            }
        }
        */
        RaycastHit hit;

        if (Physics.Raycast(hoverPoint1.transform.position, -Vector3.up, out hit, hoverHeight))
        {
            body.AddForceAtPosition(hit.point * hoverForce * (1.0f - (hit.distance / hoverHeight)), hoverPoint1.transform.position);

            grounded = true;
            Debug.DrawLine(hoverPoint1.transform.position, hit.point, Color.red);

        }
        else
        {
            grounded = false;

        }


        //--------MOVEMENT--------
        // Main Thrust
        thrust = 0.0f;
        float acceleration = Input.GetAxis("Vertical");



        if (acceleration > deadZone)
            thrust = acceleration * forwardAcceleration;
        else if (acceleration < -deadZone)
            thrust = acceleration * reverseAcceleration;

        // Turning
        turnValue = 0.0f;
        float turnAxis = Input.GetAxis("Horizontal");
        if (Mathf.Abs(turnAxis) > deadZone && body.velocity.sqrMagnitude > 5f)
            turnValue = turnAxis;
        //--------MOVEMENT--------



        //--------MOVEMENT--------

        //var emissionRate = 0;



        if (grounded == true)
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
        Debug.Log(Mathf.Abs(thrust));

        if (Mathf.Abs(thrust) > 0)
        {
            body.AddForce(transform.forward * thrust);
        }
        // Handle Turn forces
        if (turnValue > 0)
        {
            body.AddRelativeTorque(Vector3.up * turnValue * turnStrength);
        }
        else if (turnValue < 0)
        {
            body.AddRelativeTorque(Vector3.up * turnValue * turnStrength);
        }

        // Limit max velocity
        if (body.velocity.sqrMagnitude > (body.velocity.normalized * maxVelocity).sqrMagnitude)
        {
            body.velocity = body.velocity.normalized * maxVelocity;
        }
        //--------MOVEMENT--------

    }
}