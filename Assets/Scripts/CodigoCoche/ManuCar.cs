using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuCar : MonoBehaviour
{

    //--------MOVEMENT--------
    float deadZone = 0.1f;

    public float groundedDrag = 3f;

    private float maxVelocity = 100;

    private float forwardAcceleration = 1400f;
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
    public ParticleSystem[] dustTrails = new ParticleSystem[2];
    public Transform[] wheelTransform = new Transform[4]; //these are the transforms for our 4 wheels
    //--------GAMEOBJECTS--------

    // Objetos para el canvas
    private GameObject obj;
    private Canvas c;


    public float Showtime = 0f;


    public Vector3 center;
    public Vector3 localF;


    public List<Suspension>  ruedas; //referencia a la clase suspension
    private Suspension rueda;


    void Start()
    {
        // --- Hacemos referencia a la función canvas para saber si tenemos el nitro lleno o no ---
        obj = GameObject.Find("HUD");
        //c = obj.GetComponent<Canvas>();

        //coche = GetComponent<Rigidbody>();

        //--------GAMEOBJECTS--------
        body = GetComponent<Rigidbody>();
        center = body.centerOfMass;
        body.centerOfMass = Vector3.down; //UNO POR DEBAJO DEL VEHICULO, no es realista, pero asi sera dificil que el coche quede boca abajo

        layerMask = 1 << LayerMask.NameToLayer("Vehicle");
        layerMask = ~layerMask;

        //--------GAMEOBJECTS--------
        int i = 0;
        while(i <= 3)
        {
            rueda = transform.Find("w" + i).GetComponent<Suspension>(); //referencia  a la instancia particular/local de la clase suspension de cada rueda
            ruedas.Add(rueda);
            i++;
        }

    }


    void FixedUpdate()
    {
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
        if (Mathf.Abs(turnAxis) > deadZone /*&& body.velocity.sqrMagnitude > 5f*/)
            turnValue = turnAxis;

        //anim.SetFloat("giro", turnValue); //al giro del animator

        

        //var emissionRate = 0;

        
        GroundDetector ground;
        ground = gameObject.GetComponentInChildren<GroundDetector>();

        // Controlador de la friccion        
        if (ruedas[0].grounded == false && ruedas[1].grounded == false && ruedas[2].grounded == false && ruedas[3].grounded == false)
        {
            //emissionRate = 10;
            body.drag = 0.1f;
            thrust /= 200f;
            turnValue /= 20f;

            Debug.Log("Volando voy");
        }
        else
        {
            Debug.Log("En tierra estoy");
            body.drag = groundedDrag;
        }

        //Controlador de las particulas de las ruedas*
        for (int i = 0; i < dustTrails.Length; i++)
        {
            //var emission = dustTrails[i].emission;
            //emission.rate = new ParticleSystem.MinMaxCurve(emissionRate);
        }



        // Controlador de las fuerzas hacia adelante, atra y parado
        if (thrust > 0)
        {
            localF = transform.forward;
            //localF.y = localF.y - 0.5f;
            //center.y = center.y - 0.2f;
            //center.z = center.z + 0.5f;



            Vector3 normal0 = ruedas[0].normalVec;
            Vector3 normal1 = ruedas[1].normalVec;
            Vector3 normal2 = ruedas[2].normalVec;
            Vector3 normal3 = ruedas[3].normalVec;

            Vector3 forward0 = Vector3.ProjectOnPlane(localF, normal0);
            Vector3 forward1 = Vector3.ProjectOnPlane(localF, normal1);
            Vector3 forward2 = Vector3.ProjectOnPlane(localF, normal2);
            Vector3 forward3 = Vector3.ProjectOnPlane(localF, normal3);


            body.AddForce(forward0 * thrust / 4);
            body.AddForce(forward1 * thrust / 4);
            body.AddForce(forward2 * thrust / 4);
            body.AddForce(forward3 * thrust / 4);

            torque = turnValue * turnStrength;
        }
        else if (thrust == 0)
        {
            body.drag = 0.8f;
            torque = turnValue * turnStrength;
        }
        else
        {
            body.AddForce(transform.forward * thrust);
            torque = -turnValue * turnStrength;
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            Showtime = 0.5f;
        }

        if (Showtime > 0f)
        {
            Showtime = Showtime - (Time.deltaTime);
            Vector3 forward = transform.forward;
            forward.y = 0f;
            body.AddForce(forward * 30, ForceMode.Impulse); //aplicar impulso hacia delante local
        }
        else
        {
            //Debug.Log("se acabo el tiempo");
        }

        /*
        // Comprobaremos el nitro una vez le de a la tecla shift
        if (Input.GetKey(KeyCode.LeftShift))
        {

            // Si el nitro no está lleno no se le añadira el impulso aunque le de a la tecla Shift
            if (c.comprobarNitroLleno() != 0)
            {
                    // Si esta lleno vaciara el nitro en el CANVAS y le añade el impulso
                    Vector3 forward = transform.forward;
                    forward.y = 0f;
                    c.vaciarNitro(c.comprobarNitroLleno());

                    body.AddForce(forward* 100, ForceMode.Impulse); //aplicar impulso hacia delante local
            }
            
        }
        */

        // Manajedor del giro
        if (turnValue > 0)
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, torque, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            body.MoveRotation(body.rotation * deltaRotation);
        }
        else if (turnValue < 0 )
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, torque, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            body.MoveRotation(body.rotation * deltaRotation);
        }

        // Limitador de vel max
        if (body.velocity.sqrMagnitude > (body.velocity.normalized * maxVelocity).sqrMagnitude)
        {
            body.velocity = body.velocity.normalized * maxVelocity;
        }
        //--------MOVEMENT--------

    }
}
