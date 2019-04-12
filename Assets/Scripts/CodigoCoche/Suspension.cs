using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour
{
    private Rigidbody coche;
    private GameObject rueda; //posicion de la rueda alrededor del coche (local es el coche)
    private Transform ruedaTransform;

    public float gravityForce = 1000f;
    private float hoverForce = 1500f;
    private float hoverHeight = 0.5f;
    float hoverDamp = 50f;

    public bool grounded;
    public Vector3 distanciaPoint = new Vector3();

    public Transform hoverPoint;
    int layerMask;

    private RaycastHit hit;
    public Transform raycastPoint;
    // Works like start but before it
    public Transform ruedaReal;


    void Awake()
    {
        coche = transform.root.GetComponent<Rigidbody>();
        rueda = this.gameObject;
        hoverPoint = rueda.transform;
        Debug.Log(hoverPoint);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 ralloOrigen = rueda.position;
        layerMask = 1 << LayerMask.GetMask("coche de pruebas");
        layerMask = ~layerMask;

        ruedaReal = this.gameObject.transform.GetChild(0);

    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        float speed = coche.velocity.magnitude;




        //--------RAYCAST--------
        //  Hover Force


        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;

        if (Physics.Raycast(hoverPoint.transform.position, -transform.up, out hit, hoverHeight, layerMask))
            {
            float compression =  hoverHeight - hit.distance;
            float upwardSpeed = coche.velocity.y; 
            float elevacion = compression * hoverForce - upwardSpeed * hoverDamp;

            distanciaPoint = hit.point;

            Debug.Log(hit.normal);
            Debug.Log(transform.up);
            Debug.Log(Vector3.up);
            Debug.Log("----------------------");

            coche.AddForceAtPosition(Vector3.up * elevacion, hoverPoint.transform.position);
            grounded = true;

            ruedaReal.transform.position = Vector3.MoveTowards(transform.position, hit.point, 2f);
        }
        else
        {
            // Self levelling - returns the vehicle to horizontal when not grounded
            if (transform.position.y > hoverPoint.transform.position.y)
            {
                coche.AddForceAtPosition(hoverPoint.transform.up * gravityForce, hoverPoint.transform.position);
                grounded = false;
            }
            else
            {
                coche.AddForceAtPosition(hoverPoint.transform.up * -gravityForce, hoverPoint.transform.position);
                grounded = false;
            }
        }

        Debug.DrawRay(hit.point, transform.up, Color.red);




        /*
            if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, ))
            {
                coche.AddForceAtPosition(Vector3.up * hoverForce * (1.0f - (hit.distance / hoverHeight)), hoverPoint.transform.position);
                grounded = true;
                Debug.DrawRay(transform.position, -Vector3.up, Color.red);
            }
            else
            {
                // Self levelling - returns the vehicle to horizontal when not grounded
                if (transform.position.y > hoverPoint.transform.position.y)
                {
                    body.AddForceAtPosition(hoverPoint.transform.up * gravityForce, hoverPoint.transform.position);
                }
                else
                {
                    body.AddForceAtPosition(hoverPoint.transform.up * -gravityForce, hoverPoint.transform.position);
                }
            }
            /*

        //--------RAYCAST--------



        // down = local downwards direction
        //Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, Vector3.down, out hit, radioRueda + suspLongMaxima))
        {

            grounded = true;
            // the velocity at point of contact
            //Vector3 velocityAtTouch = parent.GetPointVelocity(hit.point);

            // calculate spring compression
            // difference in positions divided by total suspension range
            float compression = hit.distance / (suspLongMaxima + radioRueda);
            compression = -compression + 1;

            // final force
            //Vector3 force = Vector3.down * compression * spring;
            // velocity at point of contact transformed into local space

            // Vector3 t = transform.InverseTransformDirection(velocityAtTouch);

            // local x and z directions = 0
            //t.z = t.x = 0;

            // back to world space * -damping
            //Vector3 damping = transform.TransformDirection(t) * -damper;
            Vector3 finalForce = force;

            // VERY simple turning - force rigidbody in direction of wheel
            /*t = parent.transform.InverseTransformDirection(velocityAtTouch);
            t.y = 0;
            t.z = 0;

            t = transform.TransformDirection(t);
            */



    }
}
