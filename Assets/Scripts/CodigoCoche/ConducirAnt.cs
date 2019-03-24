using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConducirAnt : MonoBehaviour
{

    public float enginePower = 150.0f;
    public float power = 0.0f;
    public float brake = 0.0f;
    public float steer = 0.0f;
    public float maxSteer = 25.0f;
    public float velocity = 250.0f;
    public WheelCollider FrontLeft;
    public WheelCollider FrontRight;
    public WheelCollider RearLeft;
    public WheelCollider RearRight;
    
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0.0f, -0.1f, 0.3f);

        Debug.Log("Inicio");

    }

    void Update()
    {

        power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime * velocity;
        steer = Input.GetAxis("Horizontal") * maxSteer;

        brake = Input.GetKey("space") ? rb.mass * 0.1f : 0.0f;

        FrontLeft.steerAngle = steer;
        FrontRight.steerAngle = steer;

        if (brake > 0.0)
        {
            FrontLeft.brakeTorque = brake;
            FrontRight.brakeTorque = brake;
            RearLeft.brakeTorque = brake;
            RearRight.brakeTorque = brake;
            RearLeft.motorTorque = 0.0f;
            RearRight.motorTorque = 0.0f;
        }
        else
        {
            FrontLeft.brakeTorque = 0;
            FrontRight.brakeTorque = 0;
            RearLeft.brakeTorque = 0;
            RearRight.brakeTorque = 0;
            RearLeft.motorTorque = power;
            RearRight.motorTorque = power;
        }



    }

}
