using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCar : MonoBehaviour
{

    public float speed = 90f;
    public float turnSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 0.1f;
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;


    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);




            Quaternion slopeRotation = Quaternion.FromToRotation(transform.up, hit.normal);
            transform.rotation = Quaternion.Slerp(transform.rotation,slopeRotation * transform.rotation,10*Time.deltaTime);
            Debug.DrawRay(hit.point, hit.normal, Color.red);


        }

        carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

    }
}
