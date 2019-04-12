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
    private float angles;
    private Transform siguienteWaypoint;
    //Creamos una variable para guardar el WAYPOINT anterior al actual para calcular el angulo entre éste y el siguiente
    private Transform siguienteWaypointMasUno;
    Rigidbody body2;
    public float velocidadGiro = 50f;


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
               // Debug.Log(potencialWaypoint2);
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

        //--------GAMEOBJECTS--------
        body2 = GetComponent<Rigidbody>();
        
        body2.centerOfMass = Vector3.down; //UNO POR DEBAJO DEL VEHICULO, no es realista, pero asi sera dificil que el coche quede boca abajo
        //--------GAMEOBJECTS--------

    }

    void Update()
    {
        Vector3 newPos = Vector3.MoveTowards(body2.transform.position, siguienteWaypoint.position, speed2 * Time.deltaTime);
        body2.MovePosition(newPos);

        //Si estamos en currentWaypoint = 0, el waypoint anterior será el último del array de waypoints
        if (currentWaypoint2 == waypoints2.Length - 1)
        {
            siguienteWaypointMasUno = waypoints2[0];
        }

        else
        {
            siguienteWaypointMasUno = waypoints2[currentWaypoint2 + 1];
        }


        float angle = Vector3.Angle(siguienteWaypoint.position, siguienteWaypointMasUno.position);

        if (contact2)
        {
        
            body2.transform.Rotate(Vector3.up, angle);
            currentWaypoint2 = (currentWaypoint2 + 1) % waypoints2.Length;
            siguienteWaypoint = waypoints2[currentWaypoint2];
            contact2 = false;

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