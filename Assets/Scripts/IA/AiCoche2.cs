using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCoche2 : MonoBehaviour
{

    //--------WAYPOINT--------
    public GameObject waypointContainer2;
    private Transform[] waypoints2;
    private int currentWaypoint2 = 0;
    private bool contact2 = false;
    public float speed2 = 100;
    private Vector3 m_EulerAngleVelocity2;
    public float Showtime = 0f;
    public int counter = 5;

    private Transform siguienteWaypoint;

    Rigidbody body2;


    //--------GAMEOBJECTS--------

    // -- Crear el array de los waypoints a partir de los hijos del objeto WayPoints
    void GetWaypoints()
    {
        Transform[] potencialWaypoints2 = waypointContainer2.GetComponentsInChildren<Transform>();
        waypoints2 = new Transform[potencialWaypoints2.Length - 1];
        // Quita el padre de los waypoint
        int i = 0;
        foreach (Transform potencialWaypoint2 in potencialWaypoints2)
        {

            if (potencialWaypoint2 != waypointContainer2.transform)
            {
                Debug.Log(potencialWaypoint2);
                waypoints2[i++] = potencialWaypoint2;
            }

        }

    }

    void Start()
    {
        counter = 0;
        // -- Creamos array de waypoints
        GetWaypoints();

        siguienteWaypoint = waypoints2[currentWaypoint2];

        // Velocidad del angulo
        m_EulerAngleVelocity2 = new Vector3(0, 50, 0);
        //coche = GetComponent<Rigidbody>();

        //--------GAMEOBJECTS--------
        body2 = GetComponent<Rigidbody>();
        body2.centerOfMass = Vector3.down; //UNO POR DEBAJO DEL VEHICULO, no es realista, pero asi sera dificil que el coche quede boca abajo
        //--------GAMEOBJECTS--------

    }

    void Update()
    {
        Vector3 newPos = Vector3.MoveTowards(body2.transform.position, siguienteWaypoint.position, speed2 * Time.deltaTime);
        body2.MovePosition(newPos);
        float angles;
        angles = newPos.x / newPos.magnitude;
        //transform.rotation = Quaternion.Euler(angles);
        Vector3 relativePos = (siguienteWaypoint.position + new Vector3(0, 0.1f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity2 * Time.deltaTime);



        if (contact2)
        {
         
            //body.AddTorque(relativePos * Time.deltaTime);
            body2.MoveRotation(rotation); //* deltaRotation);
            // Debug.Log("CurrentWayPointBefore: " + currentWaypoint2);
            currentWaypoint2 = (currentWaypoint2 + 1) % waypoints2.Length;
            siguienteWaypoint = waypoints2[currentWaypoint2];
            //S Debug.Log("CurrentWayPointAfter: " + currentWaypoint2);
            contact2 = false;
            //Debug.Log("CONTACTO COCHE 2! - CurrentWayPoint: " + currentWaypoint2);

        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == siguienteWaypoint)
        {
          
           contact2 = true;

        }
    }
}