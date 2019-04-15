using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CarController2 : MonoBehaviour
{
    [SerializeField] private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;
    [SerializeField] private WheelCollider[] m_WheelColliders = new WheelCollider[4];
    [SerializeField] private GameObject[] m_WheelMeshes = new GameObject[4];
    [SerializeField] private Vector3 m_CentreOfMassOffset;
    [SerializeField] private float m_MaximumSteerAngle;
    [Range(0, 1)] [SerializeField] private float m_SteerHelper; // 0 is raw physics , 1 the car will grip in the direction it is facing
    [Range(0, 1)] [SerializeField] private float m_TractionControl; // 0 is no traction control, 1 is full interference
    [SerializeField] private float m_FullTorqueOverAllWheels;
    [SerializeField] private float m_ReverseTorque;
    [SerializeField] private float m_MaxHandbrakeTorque;
    [SerializeField] private float m_Downforce = 100f;
    [SerializeField] private SpeedType m_SpeedType;
    [SerializeField] private float m_Topspeed = 200;
    [SerializeField] private float m_SlipLimit;
    [SerializeField] private float m_BrakeTorque;

    private Quaternion[] m_WheelMeshLocalRotations;
    private Vector3 m_Prevpos, m_Pos;
    private float m_SteerAngle;
    private float m_OldRotation;
    private float m_CurrentTorque;
    private Rigidbody m_Rigidbody;

    public float CurrentSpeed { get { return m_Rigidbody.velocity.magnitude * 2.23693629f; } }
    public float MaxSpeed { get { return m_Topspeed; } }




    //-----------------MIO----------------------------------------------------------------------------------------------
    float thrust = 0f;
    private float turnStrength = 80f;

    public float turnValue = 0f;
    private float torque = 0f;

    public Vector3 center;
    public Vector3 localF;

    private Suspension rueda;
    public List<Suspension> ruedas; //referencia a la clase suspension
    public float groundedDrag = 3f;

    //-----------------MIO----------------------------------------------------------------------------------------------


    // Use this for initialization
    private void Start()
    {
        m_WheelMeshLocalRotations = new Quaternion[4];
        for (int i = 0; i < 4; i++)
        {
            m_WheelMeshLocalRotations[i] = m_WheelMeshes[i].transform.localRotation;
        }
        m_WheelColliders[0].attachedRigidbody.centerOfMass = m_CentreOfMassOffset;

        m_MaxHandbrakeTorque = float.MaxValue;

        m_Rigidbody = GetComponent<Rigidbody>();
        m_CurrentTorque = m_FullTorqueOverAllWheels - (m_TractionControl * m_FullTorqueOverAllWheels);


        //-----------------MIO----------------------------------------------------------------------------------------------
        int u = 0;
        while (u <= 3)
        {
            rueda = transform.Find("w" + u).GetComponent<Suspension>(); //referencia  a la instancia particular/local de la clase suspension de cada rueda
            ruedas.Add(rueda);
            u++;
        }
        //-----------------MIO----------------------------------------------------------------------------------------------

    }



    public void Move(float steering, float accel, float footbrake)
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 position;
            m_WheelColliders[i].GetWorldPose(out position, out quat);
            m_WheelMeshes[i].transform.position = position;
            m_WheelMeshes[i].transform.rotation = quat;
        }

        //clamp input values
        steering = Mathf.Clamp(steering, -1, 1);
        accel = Mathf.Clamp(accel, 0, 1);
        footbrake = -1 * Mathf.Clamp(footbrake, -1, 0);


        //Set the steer on the front wheels.
        //Assuming that wheels 0 and 1 are the front wheels.
        m_SteerAngle = steering * m_MaximumSteerAngle;
        m_WheelColliders[0].steerAngle = m_SteerAngle;
        m_WheelColliders[1].steerAngle = m_SteerAngle;

        //-----------------MIO----------------------------------------------------------------------------------------------


        // Controlador de la friccion        
        if (ruedas[0].grounded == false && ruedas[1].grounded == false && ruedas[2].grounded == false && ruedas[3].grounded == false)
        {
            //emissionRate = 10;
            m_Rigidbody.drag = 0.1f;
            thrust /= 200f;
            turnValue /= 20f;
        }
        else
        {
            m_Rigidbody.drag = groundedDrag;
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


            m_Rigidbody.AddForce(forward0 * thrust / 4);
            m_Rigidbody.AddForce(forward1 * thrust / 4);
            m_Rigidbody.AddForce(forward2 * thrust / 4);
            m_Rigidbody.AddForce(forward3 * thrust / 4);

            torque = turnValue * turnStrength;
        }
        else if (thrust == 0)
        {
            m_Rigidbody.drag = 0.8f;
            torque = turnValue * turnStrength;
        }
        else
        {
            m_Rigidbody.AddForce(transform.forward * thrust);
            torque = -turnValue * turnStrength;
        }


        // Manajedor del giro
        if (turnValue > 0)
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, torque, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }
        else if (turnValue < 0)
        {
            Vector3 m_EulerAngleVelocity = new Vector3(0, torque, 0);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }
        //-----------------MIO----------------------------------------------------------------------------------------------

        SteerHelper();
        ApplyDrive(accel, footbrake);

        AddDownForce();
        TractionControl();
    }



    private void ApplyDrive(float accel, float footbrake)
    {

        float thrustTorque;
        switch (m_CarDriveType)
        {
            case CarDriveType.FourWheelDrive:
                thrustTorque = accel * (m_CurrentTorque / 4f);
                for (int i = 0; i < 4; i++)
                {
                    m_WheelColliders[i].motorTorque = thrustTorque;
                }
                break;
        }

        for (int i = 0; i < 4; i++)
        {
            if (CurrentSpeed > 5 && Vector3.Angle(transform.forward, m_Rigidbody.velocity) < 50f)
            {
                m_WheelColliders[i].brakeTorque = m_BrakeTorque * footbrake;
            }
            else if (footbrake > 0)
            {
                m_WheelColliders[i].brakeTorque = 0f;
                m_WheelColliders[i].motorTorque = -m_ReverseTorque * footbrake;
            }
        }
    }


    private void SteerHelper()
    {
        for (int i = 0; i < 4; i++)
        {
            WheelHit wheelhit;
            m_WheelColliders[i].GetGroundHit(out wheelhit);
            if (wheelhit.normal == Vector3.zero)
                return; // wheels arent on the ground so dont realign the rigidbody velocity
        }

        // this if is needed to avoid gimbal lock problems that will make the car suddenly shift direction
        if (Mathf.Abs(m_OldRotation - transform.eulerAngles.y) < 10f)
        {
            var turnadjust = (transform.eulerAngles.y - m_OldRotation) * m_SteerHelper;
            Quaternion velRotation = Quaternion.AngleAxis(turnadjust, Vector3.up);
            m_Rigidbody.velocity = velRotation * m_Rigidbody.velocity;
        }
        m_OldRotation = transform.eulerAngles.y;
    }


    // this is used to add more grip in relation to speed
    private void AddDownForce()
    {
        m_WheelColliders[0].attachedRigidbody.AddForce(-transform.up * m_Downforce *
                                                     m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
    }

    // crude traction control that reduces the power to wheel if the car is wheel spinning too much
    private void TractionControl()
    {
        WheelHit wheelHit;
        switch (m_CarDriveType)
        {
            case CarDriveType.FourWheelDrive:
                // loop through all wheels
                for (int i = 0; i < 4; i++)
                {
                    m_WheelColliders[i].GetGroundHit(out wheelHit);

                    AdjustTorque(wheelHit.forwardSlip);
                }
                break;
        }
    }


    private void AdjustTorque(float forwardSlip)
    {
        if (forwardSlip >= m_SlipLimit && m_CurrentTorque >= 0)
        {
            m_CurrentTorque -= 10 * m_TractionControl;
        }
        else
        {
            m_CurrentTorque += 10 * m_TractionControl;
            if (m_CurrentTorque > m_FullTorqueOverAllWheels)
            {
                m_CurrentTorque = m_FullTorqueOverAllWheels;
            }
        }
    }

}

